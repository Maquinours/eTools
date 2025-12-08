using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Xml.Linq;

namespace eTools_Ultimate.Models.Models
{
    public sealed class MainModelBrace(uint iType, string szName, IEnumerable<IModelItem> children) : ModelBrace(szName, children)
    {
        #region Fields
        private readonly uint _iType = iType; 
        #endregion

        #region Properties
        #region Backing properties
        public uint IType => _iType;
        #endregion
        #endregion
    }
}
