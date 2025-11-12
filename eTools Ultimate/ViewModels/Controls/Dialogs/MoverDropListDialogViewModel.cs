using eTools_Ultimate.Models;
using eTools_Ultimate.Resources;
using eTools_Ultimate.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace eTools_Ultimate.ViewModels.Controls.Dialogs
{
    public partial class MoverDropListDialogViewModel(Mover mover)
    {
        private DefinesService _definesService = App.Services.GetRequiredService<DefinesService>();
        public string Title => String.Format(App.Services.GetRequiredService<IStringLocalizer<Translations>>()["{0} drop list"], mover.Name);

        public ICollectionView DropListView => new ListCollectionView(mover.Drops);
        public List<KeyValuePair<int, string>> ItemIdentifiers => [.._definesService.ReversedItemDefines];
        public List<KeyValuePair<int, string>> ItemKind3Identifiers => [.._definesService.ReversedItemKind3Defines];
    }
}
