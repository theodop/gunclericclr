using GunCleric.Atoms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Items
{
    public class ItemComponent : IAtomComponent
    {
        public Atom Atom { get; set; }
        public Type GetComponentInterface() => typeof(ItemComponent);

        public ItemSlotType SlotType { get; set; }

        public ItemComponent(Atom atom, ItemSlotType slotType = ItemSlotType.None)
        {
            SlotType = slotType;
        }
    }
}
