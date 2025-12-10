using eTools_Ultimate.Models;
using eTools_Ultimate.Resources;
using eTools_Ultimate.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace eTools_Ultimate.Helpers
{
    internal class MotionIdentifierValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is not string identifier)
                throw new InvalidOperationException("MoverIdentifierValidationRule::Validate exception : value is not a string");

            if (!Script.TryGetNumberFromString(identifier, out int id))
                return new ValidationResult(true, null);

            MotionsService motionsService = App.Services.GetRequiredService<MotionsService>();
            IStringLocalizer<Translations> localizer = App.Services.GetRequiredService<IStringLocalizer<Translations>>();

            ICollectionView motionsView = CollectionViewSource.GetDefaultView(motionsService.Motions);

            if (motionsService.Motions.Any(x => x.DwId == id && x != motionsView.CurrentItem))
                return new ValidationResult(false, localizer["This identifier is already taken by another motion."]);

            return new ValidationResult(true, null);
        }
    }
}
