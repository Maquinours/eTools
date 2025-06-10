namespace eTools_Ultimate.Models
{
    public enum PatchModificationType
    {
        Added,
        Changed,
        Removed,
        Fixed,
        Improved,
        Updated
    }
    public record class PatchModification(string Text, PatchModificationType Type);
    public record class Patch(string Version, DateTime Date, PatchModification[] Modifications);
    //{
    //    public string Version { get; }
    //    public DateTime Date { get; }
    //    public PatchModification[] Modifications {get; }

    //    [JsonConstructor]
    //    public Patch(string version, DateTime date, PatchModification[] modifications)
    //    {
    //        Version = version;
    //        Date = date;
    //        Modifications = modifications;
    //    }
    //}
}
