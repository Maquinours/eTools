using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace eTools_Ultimate.Models.Movers
{
    public class DropKindGenerator(IEnumerable<DropKind> dropKinds) : IDisposable
    {
        #region Fields
        private readonly ObservableCollection<DropKind> _dropKinds = [.. dropKinds];
        #endregion

        #region Properties
        #region Backing properties
        public ObservableCollection<DropKind> DropKinds => _dropKinds;
        #endregion
        #endregion


        #region Methods
        public void Dispose()
        {
            foreach (DropKind dropKind in DropKinds)
                dropKind.Dispose();
            DropKinds.Clear();

            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
