#if __MOVERS
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Common
{
    public enum MoverTypes
    {
        NPC,
        CHARACTER,
        MONSTER,
        PET
    }

    public class MoverType
    {
        public string[] Identifiers { get; set; }
    }

    public class MoverProp : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _dwId;
        private string _szName;
        private string _dwAi;
        private int _dwStr;
        private int _dwSta;
        private int _dwDex;
        private int _dwInt;
        private int _dwHR;
        private int _dwER;
        private int _dwRace;
        private string _dwBelligerence;
        private int _dwGender;
        private int _dwLevel;
        private int _dwFlightLevel;
        private int _dwSize;
        private string _dwClass;
        private int _bIfParts;
        private int _nChaotic;
        private int _dwUseable;
        private int _dwActionRadius;
        private int _dwAtkMin;
        private int _dwAtkMax;
        private string _dwAtk1;
        private string _dwAtk2;
        private string _dwAtk3;
        private string _dwAtk4;
        private float _fFrame;
        private int _dwOrthograde;
        private int _dwThrustRate;
        private int _dwChestRate;
        private int _dwHeadRate;
        private int _dwArmRate;
        private int _dwLegRate;
        private int _dwAttackSpeed;
        private int _dwReAttackDelay;
        private int _dwAddHp;
        private int _dwAddMp;
        private int _dwNaturalArmor;
        private int _nAbrasion;
        private int _nHardness;
        private int _dwAdjAtkDelay;
        private int _eElementType;
        private int _wElementAtk;
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
        private string _dwSourceMaterial;
        private int _dwMaterialAmount;
        private int _dwCohesion;
        private int _dwHoldingTime;
        private int _dwCorrectionValue;
        private long _nExpValue;
        private int _nFxpValue;
        private int _nBodyState;
        private int _dwAddAbility;
        private int _bKillable;
        private string _dwVirtItem1;
        private string _dwVirtItem2;
        private string _dwVirtItem3;
        private int _bVirtType1;
        private int _bVirtType2;
        private int _bVirtType3;
        private string _dwSndAtk1;
        private string _dwSndAtk2;
        private string _dwSndDie1;
        private string _dwSndDie2;
        private string _dwSndDmg1;
        private string _dwSndDmg2;
        private string _dwSndDmg3;
        private string _dwSndIdle1;
        private string _dwSndIdle2;
        private string _szComment;
        private string _dwAreaColor;
        private string _szNpcMark;
        private int _dwMadrigalGiftPoint;

        public string DwId { get => _dwId; set { if (_dwId != value) { _dwId = value; NotifyPropertyChanged(); } } }
        public string SzName { get => _szName; set { if (_szName != value) { _szName = value; NotifyPropertyChanged(); } } }
        public string DwAi { get => _dwAi; set { if (_dwAi != value) { _dwAi = value; NotifyPropertyChanged(); } } }
        public int DwStr { get => _dwStr; set { if (_dwStr != value) { _dwStr = value; NotifyPropertyChanged(); } } }
        public int DwSta { get => _dwSta; set { if (_dwSta != value) { _dwSta = value; NotifyPropertyChanged(); } } }
        public int DwDex { get => _dwDex; set { if (_dwDex != value) { _dwDex = value; NotifyPropertyChanged(); } } }
        public int DwInt { get => _dwInt; set { if (_dwInt != value) { _dwInt = value; NotifyPropertyChanged(); } } }
        public int DwHR { get => _dwHR; set { if (_dwHR != value) { _dwHR = value; NotifyPropertyChanged(); } } }
        public int DwER { get => _dwER; set { if (_dwER != value) { _dwER = value; NotifyPropertyChanged(); } } }
        public int DwRace { get => _dwRace; set { if (_dwRace != value) { _dwRace = value; NotifyPropertyChanged(); } } }
        public string DwBelligerence { get => _dwBelligerence; set { if (_dwBelligerence != value) { _dwBelligerence = value; NotifyPropertyChanged(); } } }
        public int DwGender { get => _dwGender; set { if (_dwGender != value) { _dwGender = value; NotifyPropertyChanged(); } } }
        public int DwLevel { get => _dwLevel; set { if (_dwLevel != value) { _dwLevel = value; NotifyPropertyChanged(); } } }
        public int DwFlightLevel { get => _dwFlightLevel; set { if (_dwFlightLevel != value) { _dwFlightLevel = value; NotifyPropertyChanged(); } } }
        public int DwSize { get => _dwSize; set { if (_dwSize != value) { _dwSize = value; NotifyPropertyChanged(); } } }
        public string DwClass { get => _dwClass; set { if (_dwClass != value) { _dwClass = value; NotifyPropertyChanged(); } } }
        public int BIfParts { get => _bIfParts; set { if (_bIfParts != value) { _bIfParts = value; NotifyPropertyChanged(); } } }
        public int NChaotic { get => _nChaotic; set { if (_nChaotic != value) { _nChaotic = value; NotifyPropertyChanged(); } } }
        public int DwUseable { get => _dwUseable; set { if (_dwUseable != value) { _dwUseable = value; NotifyPropertyChanged(); } } }
        public int DwActionRadius { get => _dwActionRadius; set { if (_dwActionRadius != value) { _dwActionRadius = value; NotifyPropertyChanged(); } } }
        public int DwAtkMin { get => _dwAtkMin; set { if (_dwAtkMin != value) { _dwAtkMin = value; NotifyPropertyChanged(); } } }
        public int DwAtkMax { get => _dwAtkMax; set { if (_dwAtkMax != value) { _dwAtkMax = value; NotifyPropertyChanged(); } } }
        public string DwAtk1 { get => _dwAtk1; set { if (_dwAtk1 != value) { _dwAtk1 = value; NotifyPropertyChanged(); } } }
        public string DwAtk2 { get => _dwAtk2; set { if (_dwAtk2 != value) { _dwAtk2 = value; NotifyPropertyChanged(); } } }
        public string DwAtk3 { get => _dwAtk3; set { if (_dwAtk3 != value) { _dwAtk3 = value; NotifyPropertyChanged(); } } }
        public string DwAtk4 { get => _dwAtk4; set { if (_dwAtk4 != value) { _dwAtk4 = value; NotifyPropertyChanged(); } } }
        public float FFrame { get => _fFrame; set { if (_fFrame != value) { _fFrame = value; NotifyPropertyChanged(); } } }
        public int DwOrthograde { get => _dwOrthograde; set { if (_dwOrthograde != value) { _dwOrthograde = value; NotifyPropertyChanged(); } } }
        public int DwThrustRate { get => _dwThrustRate; set { if (_dwThrustRate != value) { _dwThrustRate = value; NotifyPropertyChanged(); } } }
        public int DwChestRate { get => _dwChestRate; set { if (_dwChestRate != value) { _dwChestRate = value; NotifyPropertyChanged(); } } }
        public int DwHeadRate { get => _dwHeadRate; set { if (_dwHeadRate != value) { _dwHeadRate = value; NotifyPropertyChanged(); } } }
        public int DwArmRate { get => _dwArmRate; set { if (_dwArmRate != value) { _dwArmRate = value; NotifyPropertyChanged(); } } }
        public int DwLegRate { get => _dwLegRate; set { if (_dwLegRate != value) { _dwLegRate = value; NotifyPropertyChanged(); } } }
        public int DwAttackSpeed { get => _dwAttackSpeed; set { if (_dwAttackSpeed != value) { _dwAttackSpeed = value; NotifyPropertyChanged(); } } }
        public int DwReAttackDelay { get => _dwReAttackDelay; set { if (_dwReAttackDelay != value) { _dwReAttackDelay = value; NotifyPropertyChanged(); } } }
        public int DwAddHp { get => _dwAddHp; set { if (_dwAddHp != value) { _dwAddHp = value; NotifyPropertyChanged(); } } }
        public int DwAddMp { get => _dwAddMp; set { if (_dwAddMp != value) { _dwAddMp = value; NotifyPropertyChanged(); } } }
        public int DwNaturalArmor { get => _dwNaturalArmor; set { if (_dwNaturalArmor != value) { _dwNaturalArmor = value; NotifyPropertyChanged(); } } }
        public int NAbrasion { get => _nAbrasion; set { if (_nAbrasion != value) { _nAbrasion = value; NotifyPropertyChanged(); } } }
        public int NHardness { get => _nHardness; set { if (_nHardness != value) { _nHardness = value; NotifyPropertyChanged(); } } }
        public int DwAdjAtkDelay { get => _dwAdjAtkDelay; set { if (_dwAdjAtkDelay != value) { _dwAdjAtkDelay = value; NotifyPropertyChanged(); } } }
        public int EElementType { get => _eElementType; set { if (_eElementType != value) { _eElementType = value; NotifyPropertyChanged(); } } }
        public int WElementAtk { get => _wElementAtk; set { if (_wElementAtk != value) { _wElementAtk = value; NotifyPropertyChanged(); } } }
        public int DwHideLevel { get => _dwHideLevel; set { if (_dwHideLevel != value) { _dwHideLevel = value; NotifyPropertyChanged(); } } }
        public float FSpeed { get => _fSpeed; set { if (_fSpeed != value) { _fSpeed = value; NotifyPropertyChanged(); } } }
        public int DwShelter { get => _dwShelter; set { if (_dwShelter != value) { _dwShelter = value; NotifyPropertyChanged(); } } }
        public int DwFlying { get => _dwFlying; set { if (_dwFlying != value) { _dwFlying = value; NotifyPropertyChanged(); } } }
        public int DwJumpIng { get => _dwJumpIng; set { if (_dwJumpIng != value) { _dwJumpIng = value; NotifyPropertyChanged(); } } }
        public int DwAirJump { get => _dwAirJump; set { if (_dwAirJump != value) { _dwAirJump = value; NotifyPropertyChanged(); } } }
        public int BTaming { get => _bTaming; set { if (_bTaming != value) { _bTaming = value; NotifyPropertyChanged(); } } }
        public int DwResisMgic { get => _dwResisMgic; set { if (_dwResisMgic != value) { _dwResisMgic = value; NotifyPropertyChanged(); } } }
        public int NResistElecricity { get => _nResistElecricity; set { if (_nResistElecricity != value) { _nResistElecricity = value; NotifyPropertyChanged(); } } }
        public int NResistFire { get => _nResistFire; set { if (_nResistFire != value) { _nResistFire = value; NotifyPropertyChanged(); } } }
        public int NResistWind { get => _nResistWind; set { if (_nResistWind != value) { _nResistWind = value; NotifyPropertyChanged(); } } }
        public int NResistWater { get => _nResistWater; set { if (_nResistWater != value) { _nResistWater = value; NotifyPropertyChanged(); } } }
        public int NResistEarth { get => _nResistEarth; set { if (_nResistEarth != value) { _nResistEarth = value; NotifyPropertyChanged(); } } }
        public int DwCash { get => _dwCash; set { if (_dwCash != value) { _dwCash = value; NotifyPropertyChanged(); } } }
        public string DwSourceMaterial { get => _dwSourceMaterial; set { if (_dwSourceMaterial != value) { _dwSourceMaterial = value; NotifyPropertyChanged(); } } }
        public int DwMaterialAmount { get => _dwMaterialAmount; set { if (_dwMaterialAmount != value) { _dwMaterialAmount = value; NotifyPropertyChanged(); } } }
        public int DwCohesion { get => _dwCohesion; set { if (_dwCohesion != value) { _dwCohesion = value; NotifyPropertyChanged(); } } }
        public int DwHoldingTime { get => _dwHoldingTime; set { if (_dwHoldingTime != value) { _dwHoldingTime = value; NotifyPropertyChanged(); } } }
        public int DwCorrectionValue { get => _dwCorrectionValue; set { if (_dwCorrectionValue != value) { _dwCorrectionValue = value; NotifyPropertyChanged(); } } }
        public long NExpValue { get => _nExpValue; set { if (_nExpValue != value) { _nExpValue = value; NotifyPropertyChanged(); } } }
        public int NFxpValue { get => _nFxpValue; set { if (_nFxpValue != value) { _nFxpValue = value; NotifyPropertyChanged(); } } }
        public int NBodyState { get => _nBodyState; set { if (_nBodyState != value) { _nBodyState = value; NotifyPropertyChanged(); } } }
        public int DwAddAbility { get => _dwAddAbility; set { if (_dwAddAbility != value) { _dwAddAbility = value; NotifyPropertyChanged(); } } }
        public int BKillable { get => _bKillable; set { if (_bKillable != value) { _bKillable = value; NotifyPropertyChanged(); } } }
        public string DwVirtItem1 { get => _dwVirtItem1; set { if (_dwVirtItem1 != value) { _dwVirtItem1 = value; NotifyPropertyChanged(); } } }
        public string DwVirtItem2 { get => _dwVirtItem2; set { if (_dwVirtItem2 != value) { _dwVirtItem2 = value; NotifyPropertyChanged(); } } }
        public string DwVirtItem3 { get => _dwVirtItem3; set { if (_dwVirtItem3 != value) { _dwVirtItem3 = value; NotifyPropertyChanged(); } } }
        public int BVirtType1 { get => _bVirtType1; set { if (_bVirtType1 != value) { _bVirtType1 = value; NotifyPropertyChanged(); } } }
        public int BVirtType2 { get => _bVirtType2; set { if (_bVirtType2 != value) { _bVirtType2 = value; NotifyPropertyChanged(); } } }
        public int BVirtType3 { get => _bVirtType3; set { if (_bVirtType3 != value) { _bVirtType3 = value; NotifyPropertyChanged(); } } }
        public string DwSndAtk1 { get => _dwSndAtk1; set { if (_dwSndAtk1 != value) { _dwSndAtk1 = value; NotifyPropertyChanged(); } } }
        public string DwSndAtk2 { get => _dwSndAtk2; set { if (_dwSndAtk2 != value) { _dwSndAtk2 = value; NotifyPropertyChanged(); } } }
        public string DwSndDie1 { get => _dwSndDie1; set { if (_dwSndDie1 != value) { _dwSndDie1 = value; NotifyPropertyChanged(); } } }
        public string DwSndDie2 { get => _dwSndDie2; set { if (_dwSndDie2 != value) { _dwSndDie2 = value; NotifyPropertyChanged(); } } }
        public string DwSndDmg1 { get => _dwSndDmg1; set { if (_dwSndDmg1 != value) { _dwSndDmg1 = value; NotifyPropertyChanged(); } } }
        public string DwSndDmg2 { get => _dwSndDmg2; set { if (_dwSndDmg2 != value) { _dwSndDmg2 = value; NotifyPropertyChanged(); } } }
        public string DwSndDmg3 { get => _dwSndDmg3; set { if (_dwSndDmg3 != value) { _dwSndDmg3 = value; NotifyPropertyChanged(); } } }
        public string DwSndIdle1 { get => _dwSndIdle1; set { if (_dwSndIdle1 != value) { _dwSndIdle1 = value; NotifyPropertyChanged(); } } }
        public string DwSndIdle2 { get => _dwSndIdle2; set { if (_dwSndIdle2 != value) { _dwSndIdle2 = value; NotifyPropertyChanged(); } } }
        public string SzComment { get => _szComment; set { if (_szComment != value) { _szComment = value; NotifyPropertyChanged(); } } }
        public string DwAreaColor { get => _dwAreaColor; set { if (_dwAreaColor != value) { _dwAreaColor = value; NotifyPropertyChanged(); } } }
        public string SzNpcMark { get => _szNpcMark; set { if (_szNpcMark != value) { _szNpcMark = value; NotifyPropertyChanged(); } } }
        public int DwMadrigalGiftPoint { get => _dwMadrigalGiftPoint; set { if (_dwMadrigalGiftPoint != value) { _dwMadrigalGiftPoint = value; NotifyPropertyChanged(); } } }
    }

    public class Mover : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Prop_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(MoverProp.SzName))
                NotifyPropertyChanged(e.PropertyName);
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
                    if(this.Prop != null)
                        this.Prop.PropertyChanged -= Prop_PropertyChanged;

                    this._prop = value;
                    this.Prop.PropertyChanged += Prop_PropertyChanged;
                    NotifyPropertyChanged();
                }
            }
        }

        public ModelElem Model { get => this._model; set { if (value != this.Model) { this._model = value; NotifyPropertyChanged(); } } }

        public string Id { get => this.Prop.DwId; set { if (value != this.Id) { this.Prop.DwId = value; this.Model.DwIndex = value; NotifyPropertyChanged(); } } }

        public string Name { get => Project.GetInstance().GetString(Prop.SzName); set { if (value != this.Name) { Project.GetInstance().ChangeStringValue(Prop.SzName, value); NotifyPropertyChanged(); } } }

        public string ElementType { get => Project.GetInstance().GetElementNameById(Prop.EElementType); set {  if(value != this.ElementType) { Prop.EElementType = Project.GetInstance().GetElementIdByName(value); NotifyPropertyChanged(); } } }
        public MoverTypes Type { get => Project.GetInstance().GetMoverType(this); set { if (value != this.Type) { Project.GetInstance().SetMoverType(this, value); NotifyPropertyChanged(); } } }
    }
}
#endif