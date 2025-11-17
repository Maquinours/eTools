using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace eTools_Ultimate.Models.Movers
{
    public class DropKindGenerator(IEnumerable<DropKind> dropKinds)
    {
        #region Fields
        private readonly ObservableCollection<DropKind> _dropKinds = [.. dropKinds];
        #endregion

        #region Properties
        #region Backing properties
        public ObservableCollection<DropKind> DropKinds => _dropKinds;
        #endregion
        #endregion
    }
}
