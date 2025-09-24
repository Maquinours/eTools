using eTools_Ultimate.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.ViewModels.Controls.Dialogs
{
    public partial class AddMoverAiBindingDialogViewModel : ObservableObject
    {
        private DefinesService _definesService = App.Services.GetRequiredService<DefinesService>();
        private SettingsService _settingsService = App.Services.GetRequiredService<SettingsService>();

        [ObservableProperty]
        private string _item = string.Empty;

        public string[] AvailableItems => [.. _definesService.ReversedAiDefines.Where(x => !_settingsService.Settings.MoverTypesBindings.Any(y => y.Value.Contains(x.Value))).Select(x => x.Value)];
    }
}
