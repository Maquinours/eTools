using eTools;
using System;

public class DestParam
{
    public string Param { get; set; }
    public int Value { get; set; }

    public DestParam(string param, int value)
    {
        Param = param;
        Value = value;
    }
}

public class ItemProp
{
    public int NVer { get; set; }
    public string DwID { get; set; }
    public string SzName { get; set; }
    public int DwNum { get; set; }
    public int DwPackMax { get; set; }
    public string DwItemKind1 { get; set; }
    public string DwItemKind2 { get; set; }
    public string DwItemKind3 { get; set; }
    public string DwItemJob { get; set; }
    public int BPermanence { get; set; } // If item is permanent
    public int DwUseable { get; set; }
    public string DwItemSex { get; set; }
    public int DwCost { get; set; }
    public int DwEndurance { get; set; }
    public int NAbrasion { get; set; }
    public int NMaxRepair { get; set; }
    public string DwHanded { get; set; }
    public int DwFlag { get; set; }
    public string DwParts { get; set; }
    public string DwPartsub { get; set; }
    public int BPartsFile { get; set; } // model file prefix (1 = "parts", else = "item")
    public string DwExclusive { get; set; }
    public string DwBasePartsIgnore { get; set; }
    public int DwItemLV { get; set; }
    public int DwItemRare { get; set; }
    public int DwShopAble { get; set; }
    public int NLog { get; set; }
    public int BCharged { get; set; }
    public string DwLinkKindBullet { get; set; }
    public string DwLinkKind { get; set; }
    public int DwAbilityMin { get; set; }
    public int DwAbilityMax { get; set; }
    public short EItemType { get; set; }
    public short WItemEAtk { get; set; }
    public int DwParry { get; set; }
    public int DwBlockRating { get; set; }
    public int NAddSkillMin { get; set; }
    public int NAddSkillMax { get; set; }
    public string DwAtkStyle { get; set; }
    public string DwWeaponType { get; set; }
    public string DwItemAtkOrder1 { get; set; }
    public string DwItemAtkOrder2 { get; set; }
    public string DwItemAtkOrder3 { get; set; }
    public string DwItemAtkOrder4 { get; set; }
    public int TmContinuousPain { get; set; }
    public int NShellQuantity { get; set; }
    public int DwRecoil { get; set; }
    public int DwLoadingTime { get; set; }
    public int NAdjHitRate { get; set; }
    public int FAttackSpeed { get; set; }
    public int DwDmgShift { get; set; }
    public string DwAttackRange { get; set; }
    public int NProbability { get; set; }
    public string[] DwDestParam { get; set; }
    public int[] NAdjParamVal { get; set; }
    public int[] DwChgParamVal { get; set; }
    public int[] NDestData1 { get; set; }

    public string DwActiveSkill { get; set; }
    public int DwActiveSkillLv { get; set; }
    public int DwActiveSkillRate { get; set; }
    public int DwReqMp { get; set; }
    public int DwReqFp { get; set; }
    public int DwReqDisLV { get; set; }
    public int DwReSkill1 { get; set; }
    public int DwReSkillLevel1 { get; set; }
    public int DwReSkill2 { get; set; }
    public int DwReSkillLevel2 { get; set; }
    public int DwSkillReadyType { get; set; }
    public int DwSkillReady { get; set; }
    public int DwSkillRange { get; set; }
    public string DwSfxElemental { get; set; }
    public string DwSfxObj { get; set; }
    public string DwSfxObj2 { get; set; }
    public string DwSfxObj3 { get; set; }
    public string DwSfxObj4 { get; set; }
    public string DwSfxObj5 { get; set; }
    public string DwUseMotion { get; set; }
    public int DwCircleTime { get; set; }
    public int DwSkillTime { get; set; }
    public string DwExeTarget { get; set; }
    public string DwUseChance { get; set; }

    public string DwSpellRegion { get; set; }
    public int DwSpellType { get; set; }
    public string DwReferStat1 { get; set; }
    public string DwReferStat2 { get; set; }
    public string DwReferTarget1 { get; set; }
    public string DwReferTarget2 { get; set; }
    public int DwReferValue1 { get; set; }
    public int DwReferValue2 { get; set; }
    public int DwSkillType { get; set; }
    public int NItemResistElecricity { get; set; }
    public int NItemResistFire { get; set; }
    public int NItemResistWind { get; set; }
    public int NItemResistWater { get; set; }
    public int NItemResistEarth { get; set; }
    public int NEvildoing { get; set; }
    public int DwExpertLV { get; set; }
    public int DwExpertMax { get; set; }
    public string DwSubDefine { get; set; }
    public int DwExp { get; set; }
    public string DwComboStyle { get; set; }
    public float FFlightSpeed { get; set; }
    public float FFlightLRAngle { get; set; }
    public float FFlightTBAngle { get; set; }
    public int DwFlightLimit { get; set; }
    public int DwFFuelReMax { get; set; }
    public int DwAFuelReMax { get; set; }
    public int DwFuelRe { get; set; }
    public int DwLimitLevel1 { get; set; }
    public int NReflect { get; set; }
    public string DwSndAttack1 { get; set; }
    public string DwSndAttack2 { get; set; }
    public string SzIcon { get; set; }
    public string DwQuestId { get; set; }
    public string SzTextFileName { get; set; }
    public string SzCommand { get; set; }
    public int NMinLimitLevel { get; set; }
    public int NMaxLimitLevel { get; set; }
    public int NItemGroup { get; set; }
    public int NUseLimitGroup { get; set; }
    public int NMaxDuplication { get; set; }
    public int NEffectValue { get; set; }
    public int NTargetMinEnchant { get; set; }
    public int NTargetMaxEnchant { get; set; }
    public int BResetBind { get; set; }
    public int NBindCondition { get; set; }
    public int NResetBindCondition { get; set; }
    public string DwHitActiveSkillId { get; set; }
    public int DwHitActiveSkillLv { get; set; }
    public int DwHitActiveSkillProb { get; set; }
    public string DwHitActiveSkillTarget { get; set; }
    public string DwDamageActiveSkillId { get; set; }
    public int DwDamageActiveSkillLv { get; set; }
    public int DwDamageActiveSkillProb { get; set; }
    public string DwDamageActiveSkillTarget { get; set; }
    public int DwEquipActiveSkillId { get; set; }
    public int DwEquipActiveSkillLv { get; set; }
    public int DwSmelting { get; set; }
    public int DwAttsmelting { get; set; }
    public int DwGemsmelting { get; set; }
    public int DwPierce { get; set; }
    public int DwUprouse { get; set; }
    public int BAbsoluteTime { get; set; }
    public string DwItemGrade { get; set; }
    public int BCanTrade { get; set; }
    public string DwMainCategory { get; set; }
    public string DwSubCategory { get; set; }
    public int BCanHaveServerTransform { get; set; }
    public int BCanSavePotion { get; set; }
    public int BCanLooksChange { get; set; }
    public int BIsLooksChangeMaterial { get; set; }

    public DestParam[] DestParams
    {
        get
        {
            return new DestParam[] { new DestParam(DwDestParam[0], NAdjParamVal[0]), new DestParam(DwDestParam[1], NAdjParamVal[1]), new DestParam(DwDestParam[2], NAdjParamVal[2]), new DestParam(DwDestParam[3], NAdjParamVal[3]), new DestParam(DwDestParam[4], NAdjParamVal[4]), new DestParam(DwDestParam[5], NAdjParamVal[5]) };
        }
        set
        {

        }
    }
}
public class Item
{
    public ItemProp Prop { get; set; }
    public ModelElem Model { get; set; }
    public string Name
    {
        get { return Project.GetInstance().GetString(Prop.SzName); }
        set { Project.GetInstance().ChangeStringValue(Prop.SzName, value); }
    }
    public string Description
    {
        get { return Project.GetInstance().GetString(Prop.SzCommand); }
        set { Project.GetInstance().ChangeStringValue(Prop.SzCommand, value); }
    }
}