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
    internal class MoverIdentifierValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is not string identifier)
                throw new InvalidOperationException("MoverIdentifierValidationRule::Validate exception : value is not a string");

            if (!Script.TryGetNumberFromString(identifier, out int id))
                return new ValidationResult(true, null);

            MoversService moversService = App.Services.GetRequiredService<MoversService>();
            IStringLocalizer<Translations> localizer = App.Services.GetRequiredService<IStringLocalizer<Translations>>();
            
            ICollectionView moversView = CollectionViewSource.GetDefaultView(moversService.Movers);

            if (moversService.Movers.Any(x => x.Prop.DwId == id && x != moversView.CurrentItem))
                return new ValidationResult(false, localizer["This identifier is already taken by another mover."]);

            return new ValidationResult(true, null);
        }
    }
}
