using eTools_Ultimate.Models;
using eTools_Ultimate.Resources;
using eTools_Ultimate.Converters;
using Microsoft.Extensions.Localization;
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

        public PatchNotesViewModel(IStringLocalizer stringLocalizer)
        {
            // Setze den Localizer für den Converter
            PatchModificationTypeToTextConverter.SetLocalizer(stringLocalizer);
            
            // Verwende die in der Anwendung eingestellte Sprache, oder Systemsprache wenn auf "Default"
            CultureInfo culture;
            if (eTools_Ultimate.Properties.Settings.Default.Language == "Default")
            {
                // Prüfe ob die Systemsprache unterstützt wird
                var systemCulture = CultureInfo.CurrentUICulture;
                if (systemCulture.Name == "de-DE" || systemCulture.Name == "fr-FR")
                {
                    culture = systemCulture;
                }
                else
                {
                    // Fallback auf Englisch für nicht unterstützte Sprachen
                    culture = CultureInfo.InvariantCulture;
                }
            }
            else
            {
                culture = new CultureInfo(eTools_Ultimate.Properties.Settings.Default.Language);
            }
            
            // Setze die Culture für den ResourceManager
            PatchNotes.Culture = culture;
            
            // Versuche zuerst die spezifische Kultur zu laden, dann fallback auf InvariantCulture
            ResourceSet? resourceSet = PatchNotes.ResourceManager.GetResourceSet(culture, true, true);
            
            // Falls keine spezifische Kultur gefunden wird, versuche InvariantCulture
            if (resourceSet is null && culture != CultureInfo.InvariantCulture)
            {
                resourceSet = PatchNotes.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, true);
            }

            if (resourceSet is null) throw new InvalidOperationException($"Patch notes resource set is null for culture: {culture.Name}");

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
