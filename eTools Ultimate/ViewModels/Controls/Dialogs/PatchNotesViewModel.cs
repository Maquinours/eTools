using eTools_Ultimate.Models;
using eTools_Ultimate.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace eTools_Ultimate.ViewModels.Controls.Dialogs
{
    public class PatchNotesViewModel
    {
        private readonly Patch[] _patches;

        public Patch[] Patches => _patches;

        public PatchModificationType[] ModificationTypes => [.. Enum.GetValues(typeof(PatchModificationType)).Cast<PatchModificationType>()];

        public PatchNotesViewModel()
        {
            ResourceSet? resourceSet = PatchNotes.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true);

            if (resourceSet is null) throw new InvalidOperationException("Patch notes resource set is null");

            List<Patch> patches = [];

            JsonSerializerOptions jsonSerializerOptions = new()
            {
                PropertyNameCaseInsensitive = true,
            };

            foreach (DictionaryEntry resourceEntry in resourceSet)
            {
                if (resourceEntry.Value is not string value) throw new InvalidOperationException("Patch note entry is not a string");

                Patch patch = JsonSerializer.Deserialize<Patch>(value, jsonSerializerOptions) ?? throw new InvalidOperationException("Patch note entry deserialize result is null");

                patches.Add(patch);
            }

            Patch[] patchesArray = [.. patches];
            
            Array.Sort(patchesArray, (a, b) => DateTime.Compare(b.Date, a.Date));

            _patches = patchesArray;
        }
    }
}
