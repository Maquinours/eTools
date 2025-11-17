using eTools_Ultimate.Models.Movers;
using eTools_Ultimate.Resources;
using eTools_Ultimate.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.ViewModels.Controls.Dialogs
{
    public partial class AddMoverAiBindingDialogViewModel(MoverType moverType) : ObservableObject
    {
        private DefinesService _definesService = App.Services.GetRequiredService<DefinesService>();
        private SettingsService _settingsService = App.Services.GetRequiredService<SettingsService>();
        private IStringLocalizer<Translations> _localizer = App.Services.GetRequiredService<IStringLocalizer<Translations>>();

        [ObservableProperty]
        private string _item = string.Empty;

        public string[] AvailableItems => [.. _definesService.ReversedAiDefines.Where(x => !_settingsService.Settings.MoverTypesBindings.Any(y => y.Value.Contains(x.Value))).Select(x => x.Value)];

        public string Title => String.Format(_localizer["Add an AI to {0} mover type"], moverType);
    }
}
