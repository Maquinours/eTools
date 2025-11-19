using eTools_Ultimate.Exceptions;
using eTools_Ultimate.Helpers;
using eTools_Ultimate.Models;
using eTools_Ultimate.Models.Items;
using eTools_Ultimate.Models.Models;
using Microsoft.Extensions.DependencyInjection;
using Scan;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Ui;

namespace eTools_Ultimate.Services
{
    public class ItemsService
    {
        private readonly Settings _settings;
        private readonly DefinesService _definesService;
        private readonly ModelsService _modelsService;

        private readonly ObservableCollection<Item> items = [];
        private readonly ObservableDictionary<uint, Item> _itemsById;
        private readonly ObservableDictionary<(uint, uint), Item[]> _itemsByIk3AndRarity;

        public event EventHandler<ItemPropertyChangedEventArgs>? ItemPropertyChanged;

        public ObservableCollection<Item> Items => this.items;
        public ObservableDictionary<uint, Item> ItemsById => _itemsById;
        public ObservableDictionary<(uint, uint), Item[]> ItemsByIk3AndRarity => _itemsByIk3AndRarity;

        public ItemsService(SettingsService settingsService, StringsService stringsService, DefinesService definesService, ModelsService modelsService)
        {
            _settings = settingsService.Settings;
            _definesService = definesService;
            _modelsService = modelsService;
            _itemsById = new(Items.ToDictionary(x => x.DwId, x => x));
            _itemsByIk3AndRarity = new(Items.GroupBy(x => (x.DwItemKind3, x.DwItemRare)).ToDictionary(x => x.Key, x => x.ToArray()));

            Items.CollectionChanged += Items_CollectionChanged;
        }

        private void Items_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                Item[] oldItems = [.. e.OldItems.Cast<Item>()];

                foreach (Item oldItem in oldItems)
                    oldItem.PropertyChanged -= Item_PropertyChanged;

                ItemsById.RemoveRange(oldItems.Cast<Item>().Select(item => item.DwId));
                foreach (IGrouping<(uint, uint), Item> group in oldItems.GroupBy(x => (x.DwItemKind3, x.DwItemRare)))
                {
                    if (ItemsByIk3AndRarity.TryGetValue(group.Key, out Item[]? items))
                    {
                        HashSet<Item> itemsToRemove = [.. group];
                        IEnumerable<Item> newItems = items.Where(x => !itemsToRemove.Contains(x));
                        if (newItems.Any())
                            ItemsByIk3AndRarity[group.Key] = [.. newItems];
                        else
                            ItemsByIk3AndRarity.Remove(group.Key);
                    }
                    else throw new InvalidOperationException("ItemsByIk3 does not contain key for deletion");
                }
            }
            if (e.NewItems != null)
            {
                Item[] newItems = [.. e.NewItems.Cast<Item>()];

                foreach (Item newItem in newItems)
                    newItem.PropertyChanged += Item_PropertyChanged;

                ItemsById.AddRange(newItems.Select(item => new KeyValuePair<uint, Item>(item.DwId, item)));
                foreach (IGrouping<(uint, uint), Item> group in newItems.GroupBy(x => (x.DwItemKind3, x.DwItemRare)))
                {
                    if (ItemsByIk3AndRarity.TryGetValue(group.Key, out Item[]? items))
                        ItemsByIk3AndRarity[group.Key] = [.. items, .. group];
                    else
                        ItemsByIk3AndRarity[group.Key] = [.. group];
                }
            }
        }

        private void Item_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (sender is not Item item) throw new InvalidOperationException("sender is not Item");
            if (e.PropertyName is null) throw new InvalidOperationException("e.PropertyName is null");

            switch (e.PropertyName)
            {
                case nameof(Item.DwId):
                    {
                        if (e is not PropertyChangedExtendedEventArgs extendedArgs)
                            throw new InvalidOperationException("e is not PropertyChangedExtendedEventArgs");
                        if (extendedArgs.OldValue is not uint oldValue || extendedArgs.NewValue is not uint newValue)
                            throw new InvalidOperationException("extendedArgs.OldValue is not uint oldValue ||  extendedArgs.NewValue is not uint newValue");
                        if (ItemsById[oldValue] != item)
                            throw new InvalidOperationException("ItemsById[oldValue] != item");
                        if (item.DwId != newValue)
                            throw new InvalidOperationException("item.DwId != newValue");

                        ItemsById.Remove(oldValue);
                        ItemsById.Add(newValue, item);
                        break;
                    }
                case nameof(Item.DwItemKind3):
                    {
                        if (e is not PropertyChangedExtendedEventArgs extendedArgs)
                            throw new InvalidOperationException("e is not PropertyChangedExtendedEventArgs");
                        if (extendedArgs.OldValue is not uint oldValue || extendedArgs.NewValue is not uint newValue)
                            throw new InvalidOperationException("extendedArgs.OldValue is not uint oldValue ||  extendedArgs.NewValue is not uint newValue");
                        if (item.DwItemKind3 != newValue)
                            throw new InvalidOperationException("item.DwId != newValue");

                        // Deletion
                        if (ItemsByIk3AndRarity.TryGetValue((oldValue, item.DwItemRare), out Item[]? oldIk3Items))
                        {
                            IEnumerable<Item> newItems = oldIk3Items.Where(x => x != item);
                            if (newItems.Any())
                                ItemsByIk3AndRarity[(oldValue, item.DwItemRare)] = [.. newItems];
                            else
                                ItemsByIk3AndRarity.Remove((oldValue, item.DwItemRare));
                        }
                        else throw new InvalidOperationException("ItemsByIk3 does not contain key for deletion");

                        // Add
                        if (ItemsByIk3AndRarity.TryGetValue((newValue, item.DwItemRare), out Item[]? newIk3Items))
                            ItemsByIk3AndRarity[(newValue, item.DwItemRare)] = [.. newIk3Items, item];
                        else
                            ItemsByIk3AndRarity[(newValue, item.DwItemRare)] = [item];

                        break;
                    }
                case nameof(Item.DwItemRare):
                    {
                        if (e is not PropertyChangedExtendedEventArgs extendedArgs)
                            throw new InvalidOperationException("e is not PropertyChangedExtendedEventArgs");
                        if (extendedArgs.OldValue is not uint oldValue || extendedArgs.NewValue is not uint newValue)
                            throw new InvalidOperationException("extendedArgs.OldValue is not uint oldValue ||  extendedArgs.NewValue is not uint newValue");
                        if (item.DwItemRare != newValue)
                            throw new InvalidOperationException("item.DwId != newValue");

                        // Deletion
                        if (ItemsByIk3AndRarity.TryGetValue((item.DwItemKind3, oldValue), out Item[]? oldIk3Items))
                        {
                            IEnumerable<Item> newItems = oldIk3Items.Where(x => x != item);
                            if (newItems.Any())
                                ItemsByIk3AndRarity[(item.DwItemKind3, oldValue)] = [.. newItems];
                            else
                                ItemsByIk3AndRarity.Remove((item.DwItemKind3, oldValue));
                        }
                        else throw new InvalidOperationException("ItemsByIk3 does not contain key for deletion");

                        // Add
                        if (ItemsByIk3AndRarity.TryGetValue((item.DwItemKind3, newValue), out Item[]? newIk3Items))
                            ItemsByIk3AndRarity[(item.DwItemKind3, newValue)] = [.. newIk3Items, item];
                        else
                            ItemsByIk3AndRarity[(item.DwItemKind3, newValue)] = [item];

                        break;
                    }
            }

            ItemPropertyChanged?.Invoke(this, new ItemPropertyChangedEventArgs(item, e.PropertyName));
        }

        private void ClearItems()
        {
            foreach (Item item in this.Items)
                item.Dispose();
            this.Items.Clear();
        }

        public Item? GetItemById(int dwId)
        {
            return this.Items.FirstOrDefault(x => x.Id == dwId);
        }

        public void Load()
        {
            this.ClearItems();

            Dictionary<uint, Item> items = [];

            using Script script = new();

            string filePath = _settings.PropItemFilePath ?? _settings.DefaultPropItemFilePath;
            script.Load(filePath);
            while (true)
            {
                int NVer = script.GetNumber();

                if (script.EndOfStream)
                    break;

                uint dwId = (uint)script.GetNumber();
                string szName = script.GetToken();
                uint dwNum = (uint)script.GetNumber();
                uint dwPackMax = (uint)script.GetNumber();
                uint dwItemKind1 = (uint)script.GetNumber();
                uint dwItemKind2 = (uint)script.GetNumber();
                uint dwItemKind3 = (uint)script.GetNumber();
                uint dwItemJob = (uint)script.GetNumber();
                int bPermanence = script.GetNumber();
                uint dwUseable = (uint)script.GetNumber();
                uint dwItemSex = (uint)script.GetNumber();
                uint dwCost = (uint)script.GetNumber();
                uint dwEndurance = (uint)script.GetNumber();
                int nAbrasion = script.GetNumber();
                int nMaxRepair = script.GetNumber();
                uint dwHanded = (uint)script.GetNumber(); // HD_
                uint dwFlag = (uint)script.GetNumber();
                uint dwParts = (uint)script.GetNumber();
                uint dwPartsub = (uint)script.GetNumber();
                uint bPartsFile = (uint)script.GetNumber();
                uint dwExclusive = (uint)script.GetNumber(); // PARTS_
                uint dwBasePartsIgnore = (uint)script.GetNumber(); // PARTS_
                uint dwItemLV = (uint)script.GetNumber();
                uint dwItemRare = (uint)script.GetNumber();
                uint dwShopAble = (uint)script.GetNumber();
                int nLog = script.GetNumber();
                int bCharged = script.GetNumber();
                uint dwLinkKindBullet = (uint)script.GetNumber(); // IK2 or IK3
                uint dwLinkKind = (uint)script.GetNumber(); // MI; CI; PK
                uint dwAbilityMin = (uint)script.GetNumber();
                uint dwAbilityMax = (uint)script.GetNumber();
                short eItemType = (short)script.GetNumber();
                short wItemEAtk = (short)script.GetNumber();
                uint dwParry = (uint)script.GetNumber();
                uint dwBlockRating = (uint)script.GetNumber();
                int nAddSkillMin = script.GetNumber();
                int nAddSkillMax = script.GetNumber();
                uint dwAtkStyle = (uint)script.GetNumber(); // Unused
                uint dwWeaponType = (uint)script.GetNumber(); // WT_
                uint dwItemAtkOrder1 = (uint)script.GetNumber(); // AS_ or int
                uint dwItemAtkOrder2 = (uint)script.GetNumber(); // AS_ or int
                uint dwItemAtkOrder3 = (uint)script.GetNumber(); // AS_ or int
                uint dwItemAtkOrder4 = (uint)script.GetNumber(); // AS_ or int
                uint tmContinuousPain = (uint)script.GetNumber(); // Unused
                int nShellQuantity = script.GetNumber();
                uint dwRecoil = (uint)script.GetNumber(); // Unused
                uint dwLoadingTime = (uint)script.GetNumber();
                int nAdjHitRate = script.GetNumber(); // Unused
                float fAttackSpeed = script.GetFloat();
                uint dwDmgShift = (uint)script.GetNumber(); // Unused
                uint dwAttackRange = (uint)script.GetNumber(); // AR_
                int nProbability = script.GetNumber();
                uint dwDestParam1 = (uint)script.GetNumber();
                uint dwDestParam2 = (uint)script.GetNumber();
                uint dwDestParam3 = (uint)script.GetNumber();
                uint dwDestParam4 = default;
                uint dwDestParam5 = default;
                uint dwDestParam6 = default;
                if (_settings.ResourcesVersion >= 19 || _settings.FilesFormat == FilesFormats.Florist)
                {
                    dwDestParam4 = (uint)script.GetNumber();
                    dwDestParam5 = (uint)script.GetNumber();
                    dwDestParam6 = (uint)script.GetNumber();
                }
                int nAdjParamVal1 = script.GetNumber();
                int nAdjParamVal2 = script.GetNumber();
                int nAdjParamVal3 = script.GetNumber();
                int nAdjParamVal4 = default;
                int nAdjParamVal5 = default;
                int nAdjParamVal6 = default;
                if (_settings.ResourcesVersion >= 19 || _settings.FilesFormat == FilesFormats.Florist)
                {
                    nAdjParamVal4 = script.GetNumber();
                    nAdjParamVal5 = script.GetNumber();
                    nAdjParamVal6 = script.GetNumber();
                }
                // DwChgParamVal is unused
                uint dwChgParamVal1 = (uint)script.GetNumber();
                uint dwChgParamVal2 = (uint)script.GetNumber();
                uint dwChgParamVal3 = (uint)script.GetNumber();
                uint dwChgParamVal4 = default;
                uint dwChgParamVal5 = default;
                uint dwChgParamVal6 = default;
                if (_settings.ResourcesVersion >= 19 || _settings.FilesFormat == FilesFormats.Florist)
                {
                    dwChgParamVal4 = (uint)script.GetNumber();
                    dwChgParamVal5 = (uint)script.GetNumber();
                    dwChgParamVal6 = (uint)script.GetNumber();
                }
                int nDestData11 = script.GetNumber();
                int nDestData12 = script.GetNumber();
                int nDestData13 = script.GetNumber();
                int nDestData14 = default;
                int nDestData15 = default;
                int nDestData16 = default;
                if (_settings.ResourcesVersion >= 19 || _settings.FilesFormat == FilesFormats.Florist)
                {
                    nDestData14 = script.GetNumber();
                    nDestData15 = script.GetNumber();
                    nDestData16 = script.GetNumber();
                }
                uint dwActiveSkill = (uint)script.GetNumber(); // SI_ or II_
                uint dwActiveSkillLv = (uint)script.GetNumber();
                uint dwActiveSkillRate = (uint)script.GetNumber();
                uint dwReqMp = (uint)script.GetNumber();
                uint dwReqFp = (uint)script.GetNumber(); // Unused
                uint dwReqDisLV = (uint)script.GetNumber(); // Unused
                uint dwReSkill1 = (uint)script.GetNumber(); // Unused
                uint dwReSkillLevel1 = (uint)script.GetNumber(); // Unused
                uint dwReSkill2 = (uint)script.GetNumber(); // Unused
                uint dwReSkillLevel2 = (uint)script.GetNumber(); // Unused
                uint dwSkillReadyType = (uint)script.GetNumber();
                uint dwSkillReady = (uint)script.GetNumber();
                uint dwSkillRange = (uint)script.GetNumber();
                uint dwSfxElemental = (uint)script.GetNumber(); // ELEMENTAL_
                uint dwSfxObj = (uint)script.GetNumber(); // XI_
                uint dwSfxObj2 = (uint)script.GetNumber(); // XI_
                uint dwSfxObj3 = (uint)script.GetNumber(); // XI_
                uint dwSfxObj4 = (uint)script.GetNumber(); // XI_
                uint dwSfxObj5 = (uint)script.GetNumber(); // XI_
                uint dwUseMotion = (uint)script.GetNumber(); // MTI_
                uint dwCircleTime = (uint)script.GetNumber();
                uint dwSkillTime = (uint)script.GetNumber();
                uint dwExeTarget = (uint)script.GetNumber(); // EXT_ or int
                uint dwUseChance = (uint)script.GetNumber(); // WUI_
                uint dwSpellRegion = (uint)script.GetNumber(); // SRO_
                uint dwSpellType = (uint)script.GetNumber(); // Unused
                uint dwReferStat1 = (uint)script.GetNumber(); // WEAPON_ or BARUNA_ or ARMOR_
                uint dwReferStat2 = (uint)script.GetNumber(); // DST_
                uint dwReferTarget1 = (uint)script.GetNumber(); // II_ or int
                uint dwReferTarget2 = (uint)script.GetNumber(); // II_ or int
                uint dwReferValue1 = (uint)script.GetNumber();
                uint dwReferValue2 = (uint)script.GetNumber(); // Unused
                uint dwSkillType = (uint)script.GetNumber(); // Unused

                int nItemResistElecricity = default;
                int nItemResistFire = default;
                int nItemResistWind = default;
                int nItemResistWater = default;
                int nItemResistEarth = default;

                if (_settings.FilesFormat != FilesFormats.Florist)
                {
                    nItemResistElecricity = (int)(script.GetFloat() * 100.0f);
                    nItemResistFire = (int)(script.GetFloat() * 100.0f);
                    nItemResistWind = (int)(script.GetFloat() * 100.0f);
                    nItemResistWater = (int)(script.GetFloat() * 100.0f);
                    nItemResistEarth = (int)(script.GetFloat() * 100.0f);
                }

                int nEvildoing = script.GetNumber();
                uint dwExpertLV = (uint)script.GetNumber(); // Unused
                uint dwExpertMax = (uint)script.GetNumber(); // Unused
                uint dwSubDefine = (uint)script.GetNumber(); // SND_
                uint dwExp = (uint)script.GetNumber(); // Unused
                uint dwComboStyle = (uint)script.GetNumber(); // CT_
                float fFlightSpeed = script.GetFloat();
                float fFlightLRAngle = script.GetFloat();
                float fFlightTBAngle = script.GetFloat();
                uint dwFlightLimit = (uint)script.GetNumber();
                uint dwFFuelReMax = (uint)script.GetNumber();
                uint dwAFuelReMax = (uint)script.GetNumber();
                uint dwFuelRe = (uint)script.GetNumber();
                uint dwLimitLevel1 = (uint)script.GetNumber();
                int nReflect = script.GetNumber();
                uint dwSndAttack1 = (uint)script.GetNumber(); // SND_
                uint dwSndAttack2 = (uint)script.GetNumber(); // SND_
                script.GetToken(); // ""
                string szIcon = script.GetToken();
                script.GetToken(); // ""
                uint dwQuestId = (uint)script.GetNumber();
                script.GetToken(); // ""
                string szTextFileName = script.GetToken();
                script.GetToken(); // ""
                string szCommand = script.GetToken();
                int nMinLimitLevel = default;
                int nMaxLimitLevel = default;
                int nItemGroup = default;
                int nUseLimitGroup = default;
                int nMaxDuplication = default;
                int nEffectValue = default;
                int nTargetMinEnchant = default;
                int nTargetMaxEnchant = default;
                int bResetBind = default;
                int nBindCondition = default;
                int nResetBindCondition = default;
                uint dwHitActiveSkillId = default;
                uint dwHitActiveSkillLv = default;
                uint dwHitActiveSkillProb = default;
                uint dwHitActiveSkillTarget = default;
                uint dwDamageActiveSkillId = default;
                uint dwDamageActiveSkillLv = default;
                uint dwDamageActiveSkillProb = default;
                uint dwDamageActiveSkillTarget = default;
                uint dwEquipActiveSkillId = default;
                uint dwEquipActiveSkillLv = default;
                uint dwSmelting = default;
                uint dwAttsmelting = default;
                uint dwGemsmelting = default;
                uint dwPierce = default;
                uint dwUprouse = default;
                int bAbsoluteTime = default;
                uint dwItemGrade = default;
                int bCanTrade = default;
                uint dwMainCategory = default;
                uint dwSubCategory = default;
                int bCanHaveServerTransform = default;
                int bCanSavePotion = default;
                int bCanLooksChange = default;
                int bIsLooksChangeMaterial = default;

                if (_settings.ResourcesVersion >= 16 && _settings.FilesFormat != FilesFormats.Florist)
                {
                    nMinLimitLevel = script.GetNumber();
                    nMaxLimitLevel = script.GetNumber();
                    nItemGroup = script.GetNumber();
                    nUseLimitGroup = script.GetNumber();
                    nMaxDuplication = script.GetNumber();
                    nEffectValue = script.GetNumber();
                    nTargetMinEnchant = script.GetNumber();
                    nTargetMaxEnchant = script.GetNumber();
                    bResetBind = script.GetNumber();
                    nBindCondition = script.GetNumber();
                    nResetBindCondition = script.GetNumber();
                    dwHitActiveSkillId = (uint)script.GetNumber(); // SI_
                    dwHitActiveSkillLv = (uint)script.GetNumber();
                    dwHitActiveSkillProb = (uint)script.GetNumber();
                    dwHitActiveSkillTarget = (uint)script.GetNumber(); // IST_
                    dwDamageActiveSkillId = (uint)script.GetNumber(); // SI_
                    dwDamageActiveSkillLv = (uint)script.GetNumber();
                    dwDamageActiveSkillProb = (uint)script.GetNumber();
                    dwDamageActiveSkillTarget = (uint)script.GetNumber(); // IST_
                    dwEquipActiveSkillId = (uint)script.GetNumber(); // Unused
                    dwEquipActiveSkillLv = (uint)script.GetNumber(); // Unused
                    dwSmelting = (uint)script.GetNumber();
                    dwAttsmelting = (uint)script.GetNumber();
                    dwGemsmelting = (uint)script.GetNumber();
                    dwPierce = (uint)script.GetNumber();
                    dwUprouse = (uint)script.GetNumber();
                    bAbsoluteTime = script.GetNumber();
                    if (_settings.ResourcesVersion >= 18)
                    {
                        dwItemGrade = (uint)script.GetNumber(); // ITEM_GRADE_
                        bCanTrade = script.GetNumber();
                        dwMainCategory = (uint)script.GetNumber(); // TYPE1_
                        dwSubCategory = (uint)script.GetNumber(); // TYPE2_
                        bCanHaveServerTransform = script.GetNumber();
                        bCanSavePotion = script.GetNumber();
                        if (_settings.ResourcesVersion >= 19)
                        {
                            bCanLooksChange = script.GetNumber();
                            bIsLooksChangeMaterial = script.GetNumber();
                        }
                    }
                }

                /* It is possible to be at the end of stream there if there is no blank at the end of the
                 * line. So we check if the token is empty. If so, we can say that script was at the end
                 * of the stream (excluding blanks) before trying to get the latest value. So the file is
                 * incorrecty formatted.
                 * */
                if (script.Token == "" && script.EndOfStream && script.TokenType != TokenType.STRING)
                    throw new IncorrectlyFormattedFileException(filePath);

                Item item = new(
                    nVer: NVer,
                    dwId: dwId,
                    szName: szName,
                    dwNum: dwNum,
                    dwPackMax: dwPackMax,
                    dwItemKind1: dwItemKind1,
                    dwItemKind2: dwItemKind2,
                    dwItemKind3: dwItemKind3,
                    dwItemJob: dwItemJob,
                    bPermanence: bPermanence,
                    dwUseable: dwUseable,
                    dwItemSex: dwItemSex,
                    dwCost: dwCost,
                    dwEndurance: dwEndurance,
                    nAbrasion: nAbrasion,
                    nMaxRepair: nMaxRepair,
                    dwHanded: dwHanded,
                    dwFlag: dwFlag,
                    dwParts: dwParts,
                    dwPartsub: dwPartsub,
                    bPartsFile: bPartsFile,
                    dwExclusive: dwExclusive,
                    dwBasePartsIgnore: dwBasePartsIgnore,
                    dwItemLV: dwItemLV,
                    dwItemRare: dwItemRare,
                    dwShopAble: dwShopAble,
                    nLog: nLog,
                    bCharged: bCharged,
                    dwLinkKindBullet: dwLinkKindBullet,
                    dwLinkKind: dwLinkKind,
                    dwAbilityMin: dwAbilityMin,
                    dwAbilityMax: dwAbilityMax,
                    eItemType: eItemType,
                    wItemEAtk: wItemEAtk,
                    dwParry: dwParry,
                    dwBlockRating: dwBlockRating,
                    nAddSkillMin: nAddSkillMin,
                    nAddSkillMax: nAddSkillMax,
                    dwAtkStyle: dwAtkStyle,
                    dwWeaponType: dwWeaponType,
                    dwItemAtkOrder1: dwItemAtkOrder1,
                    dwItemAtkOrder2: dwItemAtkOrder2,
                    dwItemAtkOrder3: dwItemAtkOrder3,
                    dwItemAtkOrder4: dwItemAtkOrder4,
                    tmContinuousPain: tmContinuousPain,
                    nShellQuantity: nShellQuantity,
                    dwRecoil: dwRecoil,
                    dwLoadingTime: dwLoadingTime,
                    nAdjHitRate: nAdjHitRate,
                    fAttackSpeed: fAttackSpeed,
                    dwDmgShift: dwDmgShift,
                    dwAttackRange: dwAttackRange,
                    nProbability: nProbability,
                    dwDestParam1: dwDestParam1,
                    dwDestParam2: dwDestParam2,
                    dwDestParam3: dwDestParam3,
                    dwDestParam4: dwDestParam4,
                    dwDestParam5: dwDestParam5,
                    dwDestParam6: dwDestParam6,
                    nAdjParamVal1: nAdjParamVal1,
                    nAdjParamVal2: nAdjParamVal2,
                    nAdjParamVal3: nAdjParamVal3,
                    nAdjParamVal4: nAdjParamVal4,
                    nAdjParamVal5: nAdjParamVal5,
                    nAdjParamVal6: nAdjParamVal6,
                    dwChgParamVal1: dwChgParamVal1,
                    dwChgParamVal2: dwChgParamVal2,
                    dwChgParamVal3: dwChgParamVal3,
                    dwChgParamVal4: dwChgParamVal4,
                    dwChgParamVal5: dwChgParamVal5,
                    dwChgParamVal6: dwChgParamVal6,
                    nDestData11: nDestData11,
                    nDestData12: nDestData12,
                    nDestData13: nDestData13,
                    nDestData14: nDestData14,
                    nDestData15: nDestData15,
                    nDestData16: nDestData16,
                    dwActiveSkill: dwActiveSkill,
                    dwActiveSkillLv: dwActiveSkillLv,
                    dwActiveSkillRate: dwActiveSkillRate,
                    dwReqMp: dwReqMp,
                    dwReqFp: dwReqFp,
                    dwReqDisLV: dwReqDisLV,
                    dwReSkill1: dwReSkill1,
                    dwReSkillLevel1: dwReSkillLevel1,
                    dwReSkill2: dwReSkill2,
                    dwReSkillLevel2: dwReSkillLevel2,
                    dwSkillReadyType: dwSkillReadyType,
                    dwSkillReady: dwSkillReady,
                    dwSkillRange: dwSkillRange,
                    dwSfxElemental: dwSfxElemental,
                    dwSfxObj: dwSfxObj,
                    dwSfxObj2: dwSfxObj2,
                    dwSfxObj3: dwSfxObj3,
                    dwSfxObj4: dwSfxObj4,
                    dwSfxObj5: dwSfxObj5,
                    dwUseMotion: dwUseMotion,
                    dwCircleTime: dwCircleTime,
                    dwSkillTime: dwSkillTime,
                    dwExeTarget: dwExeTarget,
                    dwUseChance: dwUseChance,
                    dwSpellRegion: dwSpellRegion,
                    dwSpellType: dwSpellType,
                    dwReferStat1: dwReferStat1,
                    dwReferStat2: dwReferStat2,
                    dwReferTarget1: dwReferTarget1,
                    dwReferTarget2: dwReferTarget2,
                    dwReferValue1: dwReferValue1,
                    dwReferValue2: dwReferValue2,
                    dwSkillType: dwSkillType,
                    nItemResistElecricity: nItemResistElecricity,
                    nItemResistFire: nItemResistFire,
                    nItemResistWind: nItemResistWind,
                    nItemResistWater: nItemResistWater,
                    nItemResistEarth: nItemResistEarth,
                    nEvildoing: nEvildoing,
                    dwExpertLV: dwExpertLV,
                    dwExpertMax: dwExpertMax,
                    dwSubDefine: dwSubDefine,
                    dwExp: dwExp,
                    dwComboStyle: dwComboStyle,
                    fFlightSpeed: fFlightSpeed,
                    fFlightLRAngle: fFlightLRAngle,
                    fFlightTBAngle: fFlightTBAngle,
                    dwFlightLimit: dwFlightLimit,
                    dwFFuelReMax: dwFFuelReMax,
                    dwAFuelReMax: dwAFuelReMax,
                    dwFuelRe: dwFuelRe,
                    dwLimitLevel1: dwLimitLevel1,
                    nReflect: nReflect,
                    dwSndAttack1: dwSndAttack1,
                    dwSndAttack2: dwSndAttack2,
                    szIcon: szIcon,
                    dwQuestId: dwQuestId,
                    szTextFileName: szTextFileName,
                    szCommand: szCommand,
                    nMinLimitLevel: nMinLimitLevel,
                    nMaxLimitLevel: nMaxLimitLevel,
                    nItemGroup: nItemGroup,
                    nUseLimitGroup: nUseLimitGroup,
                    nMaxDuplication: nMaxDuplication,
                    nEffectValue: nEffectValue,
                    nTargetMinEnchant: nTargetMinEnchant,
                    nTargetMaxEnchant: nTargetMaxEnchant,
                    bResetBind: bResetBind,
                    nBindCondition: nBindCondition,
                    nResetBindCondition: nResetBindCondition,
                    dwHitActiveSkillId: dwHitActiveSkillId,
                    dwHitActiveSkillLv: dwHitActiveSkillLv,
                    dwHitActiveSkillProb: dwHitActiveSkillProb,
                    dwHitActiveSkillTarget: dwHitActiveSkillTarget,
                    dwDamageActiveSkillId: dwDamageActiveSkillId,
                    dwDamageActiveSkillLv: dwDamageActiveSkillLv,
                    dwDamageActiveSkillProb: dwDamageActiveSkillProb,
                    dwDamageActiveSkillTarget: dwDamageActiveSkillTarget,
                    dwEquipActiveSkillId: dwEquipActiveSkillId,
                    dwEquipActiveSkillLv: dwEquipActiveSkillLv,
                    dwSmelting: dwSmelting,
                    dwAttsmelting: dwAttsmelting,
                    dwGemsmelting: dwGemsmelting,
                    dwPierce: dwPierce,
                    dwUprouse: dwUprouse,
                    bAbsoluteTime: bAbsoluteTime,
                    dwItemGrade: dwItemGrade,
                    bCanTrade: bCanTrade,
                    dwMainCategory: dwMainCategory,
                    dwSubCategory: dwSubCategory,
                    bCanHaveServerTransform: bCanHaveServerTransform,
                    bCanSavePotion: bCanSavePotion,
                    bCanLooksChange: bCanLooksChange,
                    bIsLooksChangeMaterial: bIsLooksChangeMaterial
                    );

                items[item.DwId] = item;
            }

            foreach (Item item in items.Values)
                Items.Add(item);
        }
    }

    public class ItemPropertyChangedEventArgs(Item item, string propertyName) : EventArgs
    {
        public Item Item { get; } = item;
        public string PropertyName { get; } = propertyName;
    }
}
