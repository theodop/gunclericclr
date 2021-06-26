using GunCleric.Atoms;
using GunCleric.Events;
using GunCleric.Random;
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
        private Randomiser _randomiser;

        public Type GetComponentInterface() => typeof(DamagedComponent);

        public DamagedComponent(Atom atom, EventBus eventBus, Randomiser randomiser)
        {
            Atom = atom;
            _eventBus = eventBus;
            _randomiser = randomiser;
        }

        public int PreviewDamage(Damage damage) => TestDamage(damage);

        public void ApplyDamage(Damage damage)
        {
            //
        }

        private int TestDamage(Damage damage) 
            => _randomiser.GetBellCurve(damage.Impact + damage.Piercing);
    }
}
