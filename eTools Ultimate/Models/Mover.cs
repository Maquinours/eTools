using eTools_Ultimate.Helpers;
using eTools_Ultimate.Services;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Models
{
    public class MoverProp : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged<T>(string propertyName, T oldValue, T newValue)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedExtendedEventArgs(propertyName, oldValue, newValue));
        }

        //private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        private int _dwId;
        private string _szName;
        private int _dwAi;
        private int _dwStr;
        private int _dwSta;
        private int _dwDex;
        private int _dwInt;
        private int _dwHR;
        private int _dwER;
        private int _dwRace;
        private int _dwBelligerence;
        private int _dwGender;
        private int _dwLevel;
        private int _dwFlightLevel;
        private int _dwSize;
        private int _dwClass;
        private int _bIfParts;
        private int _nChaotic;
        private int _dwUseable;
        private int _dwActionRadius;
        private long _dwAtkMin;
        private long _dwAtkMax;
        private int _dwAtk1;
        private int _dwAtk2;
        private int _dwAtk3;
        private int _dwAtk4;
        private float _fFrame;
        private int _dwOrthograde;
        private int _dwThrustRate;
        private int _dwChestRate;
        private int _dwHeadRate;
        private int _dwArmRate;
        private int _dwLegRate;
        private int _dwAttackSpeed;
        private int _dwReAttackDelay;
        private long _dwAddHp;
        private int _dwAddMp;
        private int _dwNaturalArmor;
        private int _nAbrasion;
        private int _nHardness;
        private int _dwAdjAtkDelay;
        private int _eElementType;
        private short _wElementAtk;
        private int _dwHideLevel;
        private float _fSpeed;
        private int _dwShelter;
        private int _dwFlying;
        private int _dwJumpIng;
        private int _dwAirJump;
        private int _bTaming;
        private int _dwResisMgic;
        private int _nResistElecricity;
        private int _nResistFire;
        private int _nResistWind;
        private int _nResistWater;
        private int _nResistEarth;
        private int _dwCash;
        private int _dwSourceMaterial;
        private int _dwMaterialAmount;
        private int _dwCohesion;
        private int _dwHoldingTime;
        private int _dwCorrectionValue;
        private long _nExpValue;
        private int _nFxpValue;
        private int _nBodyState;
        private int _dwAddAbility;
        private int _bKillable;
        private int _dwVirtItem1;
        private int _dwVirtItem2;
        private int _dwVirtItem3;
        private int _bVirtType1;
        private int _bVirtType2;
        private int _bVirtType3;
        private int _dwSndAtk1;
        private int _dwSndAtk2;
        private int _dwSndDie1;
        private int _dwSndDie2;
        private int _dwSndDmg1;
        private int _dwSndDmg2;
        private int _dwSndDmg3;
        private int _dwSndIdle1;
        private int _dwSndIdle2;
        private string _szComment;
        private int _dwAreaColor;
        private string _szNpcMark;
        private int _dwMadrigalGiftPoint;

        public int DwId { get => _dwId; set => SetValue(ref this._dwId, value); }
        public string SzName
        {
            get => _szName;
            set
            {
                if (_szName != value)
                {
                    string oldValue = this._szName;
                    StringsService stringsService = StringsService.Instance;
                    if (!stringsService.Strings.ContainsKey(value))
                        stringsService.GenerateNewString(value);
                    _szName = value;
                    NotifyPropertyChanged(nameof(this._szName), oldValue, this._szName);
                }
            }
        }
        public int DwAi { get => _dwAi; set => SetValue(ref this._dwAi, value); }
        public int DwStr { get => _dwStr; set => SetValue(ref this._dwStr, value); }
        public int DwSta { get => _dwSta; set => SetValue(ref this._dwSta, value); }
        public int DwDex { get => _dwDex; set => SetValue(ref this._dwDex, value); }
        public int DwInt { get => _dwInt; set => SetValue(ref this._dwInt, value); }
        public int DwHR { get => _dwHR; set => SetValue(ref this._dwHR, value); }
        public int DwER { get => _dwER; set => SetValue(ref this._dwER, value); }
        public int DwRace { get => _dwRace; set => SetValue(ref this._dwRace, value); }
        public int DwBelligerence { get => _dwBelligerence; set => SetValue(ref this._dwBelligerence, value); }
        public int DwGender { get => _dwGender; set => SetValue(ref this._dwGender, value); }
        public int DwLevel { get => _dwLevel; set => SetValue(ref this._dwLevel, value); }
        public int DwFlightLevel { get => _dwFlightLevel; set => SetValue(ref this._dwFlightLevel, value); }
        public int DwSize { get => _dwSize; set => SetValue(ref this._dwSize, value); }
        public int DwClass { get => _dwClass; set => SetValue(ref this._dwClass, value); }
        public int BIfParts { get => _bIfParts; set => SetValue(ref this._bIfParts, value); }
        public int NChaotic { get => _nChaotic; set => SetValue(ref this._nChaotic, value); }
        public int DwUseable { get => _dwUseable; set => SetValue(ref this._dwUseable, value); }
        public int DwActionRadius { get => _dwActionRadius; set => SetValue(ref this._dwActionRadius, value); }
        public long DwAtkMin { get => _dwAtkMin; set => SetValue(ref this._dwAtkMin, value); } // We set it to long to handle 64 bits attack configurations
        public long DwAtkMax { get => _dwAtkMax; set => SetValue(ref this._dwAtkMax, value); }
        public int DwAtk1 { get => _dwAtk1; set => SetValue(ref this._dwAtk1, value); }
        public int DwAtk2 { get => _dwAtk2; set => SetValue(ref this._dwAtk2, value); }
        public int DwAtk3 { get => _dwAtk3; set => SetValue(ref this._dwAtk3, value); }
        public int DwAtk4 { get => _dwAtk4; set => SetValue(ref this._dwAtk4, value); }
        public float FFrame { get => _fFrame; set => SetValue(ref this._fFrame, value); }
        public int DwOrthograde { get => _dwOrthograde; set => SetValue(ref this._dwOrthograde, value); }
        public int DwThrustRate { get => _dwThrustRate; set => SetValue(ref this._dwThrustRate, value); }
        public int DwChestRate { get => _dwChestRate; set => SetValue(ref this._dwChestRate, value); }
        public int DwHeadRate { get => _dwHeadRate; set => SetValue(ref this._dwHeadRate, value); }
        public int DwArmRate { get => _dwArmRate; set => SetValue(ref this._dwArmRate, value); }
        public int DwLegRate { get => _dwLegRate; set => SetValue(ref this._dwLegRate, value); }
        public int DwAttackSpeed { get => _dwAttackSpeed; set => SetValue(ref this._dwAttackSpeed, value); }
        public int DwReAttackDelay { get => _dwReAttackDelay; set => SetValue(ref this._dwReAttackDelay, value); }
        public long DwAddHp { get => _dwAddHp; set => SetValue(ref this._dwAddHp, value); }
        public int DwAddMp { get => _dwAddMp; set => SetValue(ref this._dwAddMp, value); }
        public int DwNaturalArmor { get => _dwNaturalArmor; set => SetValue(ref this._dwNaturalArmor, value); }
        public int NAbrasion { get => _nAbrasion; set => SetValue(ref this._nAbrasion, value); }
        public int NHardness { get => _nHardness; set => SetValue(ref this._nHardness, value); }
        public int DwAdjAtkDelay { get => _dwAdjAtkDelay; set => SetValue(ref this._dwAdjAtkDelay, value); }
        public int EElementType { get => _eElementType; set => SetValue(ref this._eElementType, value); }
        public short WElementAtk { get => _wElementAtk; set => SetValue(ref this._wElementAtk, value); }
        public int DwHideLevel { get => _dwHideLevel; set => SetValue(ref this._dwHideLevel, value); }
        public float FSpeed { get => _fSpeed; set => SetValue(ref this._fSpeed, value); }
        public int DwShelter { get => _dwShelter; set => SetValue(ref this._dwShelter, value); }
        public int DwFlying { get => _dwFlying; set => SetValue(ref this._dwFlying, value); }
        public int DwJumpIng { get => _dwJumpIng; set => SetValue(ref this._dwJumpIng, value); }
        public int DwAirJump { get => _dwAirJump; set => SetValue(ref this._dwAirJump, value); }
        public int BTaming { get => _bTaming; set => SetValue(ref this._bTaming, value); }
        public int DwResisMgic { get => _dwResisMgic; set => SetValue(ref this._dwResisMgic, value); }
        public int NResistElecricity { get => _nResistElecricity; set => SetValue(ref this._nResistElecricity, value); }
        public int NResistFire { get => _nResistFire; set => SetValue(ref this._nResistFire, value); }
        public int NResistWind { get => _nResistWind; set => SetValue(ref this._nResistWind, value); }
        public int NResistWater { get => _nResistWater; set => SetValue(ref this._nResistWater, value); }
        public int NResistEarth { get => _nResistEarth; set => SetValue(ref this._nResistEarth, value); }
        public int DwCash { get => _dwCash; set => SetValue(ref this._dwCash, value); }
        public int DwSourceMaterial { get => _dwSourceMaterial; set => SetValue(ref this._dwSourceMaterial, value); }
        public int DwMaterialAmount { get => _dwMaterialAmount; set => SetValue(ref this._dwMaterialAmount, value); }
        public int DwCohesion { get => _dwCohesion; set => SetValue(ref this._dwCohesion, value); }
        public int DwHoldingTime { get => _dwHoldingTime; set => SetValue(ref this._dwHoldingTime, value); }
        public int DwCorrectionValue { get => _dwCorrectionValue; set => SetValue(ref this._dwCorrectionValue, value); }
        public long NExpValue { get => _nExpValue; set => SetValue(ref this._nExpValue, value); }
        public int NFxpValue { get => _nFxpValue; set => SetValue(ref this._nFxpValue, value); }
        public int NBodyState { get => _nBodyState; set => SetValue(ref this._nBodyState, value); }
        public int DwAddAbility { get => _dwAddAbility; set => SetValue(ref this._dwAddAbility, value); }
        public int BKillable { get => _bKillable; set => SetValue(ref this._bKillable, value); }
        public int DwVirtItem1 { get => _dwVirtItem1; set => SetValue(ref this._dwVirtItem1, value); }
        public int DwVirtItem2 { get => _dwVirtItem2; set => SetValue(ref this._dwVirtItem2, value); }
        public int DwVirtItem3 { get => _dwVirtItem3; set => SetValue(ref this._dwVirtItem3, value); }
        public int BVirtType1 { get => _bVirtType1; set => SetValue(ref this._bVirtType1, value); }
        public int BVirtType2 { get => _bVirtType2; set => SetValue(ref this._bVirtType2, value); }
        public int BVirtType3 { get => _bVirtType3; set => SetValue(ref this._bVirtType3, value); }
        public int DwSndAtk1 { get => _dwSndAtk1; set => SetValue(ref this._dwSndAtk1, value); }
        public int DwSndAtk2 { get => _dwSndAtk2; set => SetValue(ref this._dwSndAtk2, value); }
        public int DwSndDie1 { get => _dwSndDie1; set => SetValue(ref this._dwSndDie1, value); }
        public int DwSndDie2 { get => _dwSndDie2; set => SetValue(ref this._dwSndDie2, value); }
        public int DwSndDmg1 { get => _dwSndDmg1; set => SetValue(ref this._dwSndDmg1, value); }
        public int DwSndDmg2 { get => _dwSndDmg2; set => SetValue(ref this._dwSndDmg2, value); }
        public int DwSndDmg3 { get => _dwSndDmg3; set => SetValue(ref this._dwSndDmg3, value); }
        public int DwSndIdle1 { get => _dwSndIdle1; set => SetValue(ref this._dwSndIdle1, value); }
        public int DwSndIdle2 { get => _dwSndIdle2; set => SetValue(ref this._dwSndIdle2, value); }
        public string SzComment { get => _szComment; set => SetValue(ref this._szComment, value); }
        public int DwAreaColor { get => _dwAreaColor; set => SetValue(ref this._dwAreaColor, value); }
        public string SzNpcMark { get => _szNpcMark; set => SetValue(ref this._szNpcMark, value); }
        public int DwMadrigalGiftPoint { get => _dwMadrigalGiftPoint; set => SetValue(ref this._dwMadrigalGiftPoint, value); }

        private bool SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            if (!typeof(T).IsValueType && typeof(T) != typeof(string)) throw new Exception($"Mover SetValue with not safe to assign directly property {propertyName}");

            T old = field;
            field = value;
            this.NotifyPropertyChanged(propertyName, old, value);
            return true;
        }
    }

    public class Mover : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged<T>(string propertyName, T oldValue, T newValue)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedExtendedEventArgs(propertyName, oldValue, newValue));
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Prop_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(MoverProp.SzName):
                    this.NotifyPropertyChanged(nameof(this.Name));
                    break;
                case nameof(MoverProp.DwId):
                    this.NotifyPropertyChanged(nameof(this.Id));
                    this.NotifyPropertyChanged(nameof(this.Identifier));
                    break;
                case nameof(MoverProp.DwBelligerence):
                    this.NotifyPropertyChanged(nameof(this.BelligerenceIdentifier));
                    break;
                case nameof(MoverProp.DwAi):
                    this.NotifyPropertyChanged(nameof(this.AiIdentifier));
                    break;
                    // TODO: reimplement this
                    //case nameof(MoverProp.EElementType):
                    //    this.NotifyPropertyChanged(nameof(this.ElementType));
                    //    break;
                    //case nameof(MoverProp.DwAi):
                    //    this.NotifyPropertyChanged(nameof(this.Type));
                    //    break;
            }
        }

        private void ProjectStrings_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (this.Prop != null && e.Action == NotifyCollectionChangedAction.Reset || (e.OldItems != null && e.OldItems.OfType<KeyValuePair<string, string>>().Any(kvp => kvp.Key == this.Prop.SzName)) || (e.NewItems != null && e.NewItems.OfType<KeyValuePair<string, string>>().Any(kvp => kvp.Key == this.Prop.SzName)))
                NotifyPropertyChanged(nameof(this.Name));
        }

        private MoverProp _prop;
        private ModelElem _model;

        public MoverProp Prop
        {
            get => this._prop;
            set
            {
                if (value != this.Prop)
                {
                    if (this.Prop != null)
                        this.Prop.PropertyChanged -= Prop_PropertyChanged;

                    MoverProp? oldValue = this.Prop;

                    this._prop = value;
                    this._prop.PropertyChanged += Prop_PropertyChanged;

                    NotifyPropertyChanged(nameof(this.Prop), oldValue, this.Prop);
                }
            }
        }

        public ModelElem Model 
        {
            get => this._model;
            set 
            {
                if (value != this.Model)
                {
                    ModelElem? oldValue = this.Model;
                    this._model = value;
                    NotifyPropertyChanged(nameof(this.Model), oldValue, this.Model); 
                } 
            } 
        }

        public int Id { get => this.Prop.DwId; set { if (value != this.Id) { this.Prop.DwId = value; this.Model.DwIndex = value; } } } // We don't notify changes cause Prop_PropertyChanged is already doing it

        public string Identifier
        {
            get => DefinesService.Instance.ReversedMoverDefines.TryGetValue(this.Id, out string? identifier) ? identifier : this.Id.ToString();
            set
            {
                if (DefinesService.Instance.Defines.TryGetValue(value, out int val) || Int32.TryParse(value, out val))
                    this.Id = val;
            }
        }

        public string Name { get => StringsService.Instance.GetString(Prop.SzName); set { if (value != this.Name) { StringsService.Instance.ChangeStringValue(Prop.SzName, value); } } } // We don't notify changes cause ProjectStrings_CollectionChanged is already doing it

        //public string ElementType { get => Project.GetInstance().GetElementNameById(Prop.EElementType); set { if (value != this.ElementType) { Prop.EElementType = Project.GetInstance().GetElementIdByName(value); } } } // We don't notify changes cause Prop_PropertyChanged is already doing it
        //public MoverTypes Type { get => Project.GetInstance().GetMoverType(this); set { if (value != this.Type) { Project.GetInstance().SetMoverType(this, value); } } } // We don't notify changes cause Prop_PropertyChanged is already doing it

        public string BelligerenceIdentifier
        {
            get => DefinesService.Instance.ReversedBelligerenceDefines.TryGetValue(this.Prop.DwBelligerence, out string? identifier) ? identifier : this.Prop.DwBelligerence.ToString();
            set
            {
                if (DefinesService.Instance.Defines.TryGetValue(value, out int val) || Int32.TryParse(value, out val))
                    this.Prop.DwBelligerence = val;
            }
        }

        public string AiIdentifier
        {
            get => DefinesService.Instance.ReversedAiDefines.TryGetValue(this.Prop.DwAi, out string? identifier) ? identifier : this.Prop.DwAi.ToString();
            set
            {
                if (DefinesService.Instance.Defines.TryGetValue(value, out int val) || Int32.TryParse(value, out val))
                    this.Prop.DwAi = val;
            }
        }

        public Mover()
        {
            StringsService.Instance.Strings.CollectionChanged += ProjectStrings_CollectionChanged;
        }

        public void Dispose()
        {
            StringsService.Instance.Strings.CollectionChanged -= ProjectStrings_CollectionChanged;
            if (this.Prop != null)
                this.Prop.PropertyChanged -= Prop_PropertyChanged;
        }
    }
}
