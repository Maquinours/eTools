using eTools_Ultimate.Models;
using eTools_Ultimate.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace eTools_Ultimate.Selectors
{
    public class ItemTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate? SelectTemplate(object item, DependencyObject container)
        {
            if (container is FrameworkElement element && item != null && item is Item itemObj)
            {
                return itemObj.Type switch
                {
                    ItemType.Equipment => element.FindResource("EquipmentSectionTemplate") as DataTemplate,
                    ItemType.Weapon => element.FindResource("WeaponSectionTemplate") as DataTemplate,
                    ItemType.Blinkwing => element.FindResource("BlinkwingSectionTemplate") as DataTemplate,
                    _ => null
                };
            }
            return null;
        }
    }
}
