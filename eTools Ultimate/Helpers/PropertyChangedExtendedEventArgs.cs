using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Helpers
{
    public class PropertyChangedExtendedEventArgs : PropertyChangedEventArgs
    {
        public object? OldValue { get; }
        public object? NewValue { get; }

        public PropertyChangedExtendedEventArgs(string propertyName, object? oldValue, object? newValue)
            : base(propertyName)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}
