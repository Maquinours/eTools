using eTools;

public class MoverProp
{
    public string DwId { get; set; }
    public string SzName { get; set; }
    public string DwAi { get; set; }
    public int DwStr { get; set; }
    public int DwSta { get; set; }
    public int DwDex { get; set; }
    public int DwInt { get; set; }
    public int DwHR { get; set; }
    public int DwER { get; set; }
    public int DwRace { get; set; }
    public string DwBelligerence { get; set; }
    public int DwGender { get; set; }
    public int DwLevel { get; set; }
    public int DwFlightLevel { get; set; }
    public int DwSize { get; set; }
    public string DwClass { get; set; }
    public int BIfParts { get; set; }
    public int NChaotic { get; set; }
    public int DwUseable { get; set; }
    public int DwActionRadius { get; set; }
    public int DwAtkMin { get; set; }
    public int DwAtkMax { get; set; }
    public string DwAtk1 { get; set; }
    public string DwAtk2 { get; set; }
    public string DwAtk3 { get; set; }
    public string DwAtk4 { get; set; }
    public float FFrame { get; set; }
    public int DwOrthograde { get; set; }
    public int DwThrustRate { get; set; }
    public int DwChestRate { get; set; }
    public int DwHeadRate { get; set; }
    public int DwArmRate { get; set; }
    public int DwLegRate { get; set; }
    public int DwAttackSpeed { get; set; }
    public int DwReAttackDelay { get; set; }
    public int DwAddHp { get; set; }
    public int DwAddMp { get; set; }
    public int DwNaturalArmor { get; set; }
    public int NAbrasion { get; set; }
    public int NHardness { get; set; }
    public int DwAdjAtkDelay { get; set; }
    public int EElementType { get; set; }
    public int WElementAtk { get; set; }
    public int DwHideLevel { get; set; }
    public float FSpeed { get; set; }
    public int DwShelter { get; set; }
    public int DwFlying { get; set; }
    public int DwJumpIng { get; set; }
    public int DwAirJump { get; set; }
    public int BTaming { get; set; }
    public int DwResisMgic { get; set; }
    public int NResistElecricity { get; set; }
    public int NResistFire { get; set; }
    public int NResistWind { get; set; }
    public int NResistWater { get; set; }
    public int NResistEarth { get; set; }
    public int DwCash { get; set; }
    public string DwSourceMaterial { get; set; }
    public int DwMaterialAmount { get; set; }
    public int DwCohesion { get; set; }
    public int DwHoldingTime { get; set; }
    public int DwCorrectionValue { get; set; }
    public int NExpValue { get; set; }
    public int NFxpValue { get; set; }
    public int NBodyState { get; set; }
    public int DwAddAbility { get; set; }
    public int BKillable { get; set; }
    public string[] DwVirtItem { get; set; }
    public int[] BVirtType { get; set; }
    public string DwSndAtk1 { get; set; }
    public string DwSndAtk2 { get; set; }
    public string DwSndDie1 { get; set; }
    public string DwSndDie2 { get; set; }
    public string DwSndDmg1 { get; set; }
    public string DwSndDmg2 { get; set; }
    public string DwSndDmg3 { get; set; }
    public string DwSndIdle1 { get; set; }
    public string DwSndIdle2 { get; set; }
    public string SzComment { get; set; }
    public string DwAreaColor { get; set; }
    public string SzNpcMark { get; set; }
    public int DwMadrigalGiftPoint { get; set; }
}

public class Mover
{
    public MoverProp Prop { get; set; }
    public ModelElem Model { get; set; }
    public string Name
    {
        get { return Project.GetInstance().GetString(Prop.SzName); }
        set { Project.GetInstance().ChangeStringValue(Prop.SzName, value); }
    }

    public string ElementType
    {
        get { return Project.GetInstance().GetElementNameById(Prop.EElementType); }
        set { Prop.EElementType = Project.GetInstance().GetElementIdByName(value); }
    }
}