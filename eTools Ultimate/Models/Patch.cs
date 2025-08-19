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
    
    public record class PatchCategory
    {
        public PatchModification[] Added { get; init; } = [];
        public PatchModification[] Changed { get; init; } = [];
        public PatchModification[] Fixed { get; init; } = [];
        public PatchModification[] Improved { get; init; } = [];
        public PatchModification[] Removed { get; init; } = [];
        public PatchModification[] Updated { get; init; } = [];
    }
    
    public record class Patch(string Version, DateTime Date, PatchModification[] Modifications, string? DeveloperText = null, string? ImagePath = null, PatchCategory? Categories = null);
}
