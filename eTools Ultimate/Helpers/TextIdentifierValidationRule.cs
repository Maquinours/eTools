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
    internal class TextIdentifierValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is not string identifier)
                throw new InvalidOperationException("TextIdentifierValidationRule::Validate exception : value is not a string");

            TextsService textsService = App.Services.GetRequiredService<TextsService>();
            IStringLocalizer<Translations> localizer = App.Services.GetRequiredService<IStringLocalizer<Translations>>();

            ICollectionView textsView = CollectionViewSource.GetDefaultView(textsService.Texts);

            if (textsService.Texts.Any(x => x.Identifier == identifier && x != textsView.CurrentItem))
                return new ValidationResult(false, $"This identifier is already taken by another text.");

            return new ValidationResult(true, null);
        }
    }
}
