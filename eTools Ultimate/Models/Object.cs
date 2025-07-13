using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Models
{
    public class ObjectProperties
    {
        public int DwId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ModelPath { get; set; } = string.Empty;
        public float Scale { get; set; } = 1.0f;
        public int CollisionType { get; set; } = 0;
        public bool IsMovable { get; set; } = false;
        public bool IsDestructible { get; set; } = false;
        public bool IsInteractive { get; set; } = false;
        public bool CastShadow { get; set; } = true;
    }

    public class Object
    {
        public ObjectProperties Prop { get; set; } = new ObjectProperties();
    }

    public class ObjectBrace
    {
        public ObjectProperties Prop { get; set; } = new ObjectProperties();
        public ObservableCollection<object> Children { get; set; } = new ObservableCollection<object>();
    }
}