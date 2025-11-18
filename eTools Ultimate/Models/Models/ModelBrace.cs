using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Xml.Linq;

namespace eTools_Ultimate.Models.Models
{
    public class ModelBrace(string szName, IEnumerable<IModelItem> children) : IModelItem, IDisposable
    {
        #region Fields
        private readonly string _szName = szName;
        private readonly ObservableCollection<IModelItem> _children = [.. children];
        #endregion

        #region Properties
        #region Backing properties
        public string SzName => _szName;
        public ObservableCollection<IModelItem> Children => _children;
        #endregion
        #endregion

        #region Methods
        #region Public methods
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion
        #endregion
    }
}
