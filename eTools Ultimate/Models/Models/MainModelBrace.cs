using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Xml.Linq;

namespace eTools_Ultimate.Models.Models
{
    public class MainModelBrace(uint iType, string szName, IEnumerable<IModelItem> children) : IDisposable
    {
        #region Fields
        private readonly uint _iType = iType; 
        private readonly string _szName = szName;
        private readonly ObservableCollection<IModelItem> _children = [.. children];
        #endregion

        #region Properties
        #region Backing properties
        public uint IType => _iType;
        public string SzName => _szName;
        public ObservableCollection<IModelItem> Children => _children;
        #endregion
        #endregion

        #region Methods
        #region Public methods
        public void Dispose()
        {
            foreach(IModelItem child in Children)
            {
                if (child is not IDisposable disposableChild)
                    throw new InvalidOperationException("child is not IDisposable");

                disposableChild.Dispose();
            }

            Children.Clear();

            GC.SuppressFinalize(this);
        }
        #endregion
        #endregion
    }
}
