using GunCleric.Atoms;
using GunCleric.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Damaging
{
    public class DamagedComponent : IAtomComponent
    {
        public Atom Atom { get; }

        private EventBus _eventBus;

        public Type GetComponentInterface() => typeof(DamagedComponent);

        public DamagedComponent(Atom atom, EventBus eventBus)
        {
            Atom = atom;
            _eventBus = eventBus;
        }

        public int PreviewDamage(Damage damage) => TestDamage(damage);

        public void ApplyDamage(Damage damage)
        {
            //
        }

        private int TestDamage(Damage damage) => damage.Impact + damage.Piercing;
    }
}
