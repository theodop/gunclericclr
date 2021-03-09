using GunCleric.Atoms;
using GunCleric.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Damaging
{
    public class DamagerComponent : IAtomComponent
    {
        public Atom Atom { get; }

        private EventBus _eventBus;

        public Type GetComponentInterface() => typeof(DamagerComponent);

        public DamagerComponent(Atom atom, EventBus eventBus)
        {
            Atom = atom;
            _eventBus = eventBus;
        }

        public void Damage(Atom attacker, Atom victim, Damage damage)
        {
            if (victim.TryGetComponent<DamagedComponent>(out var damaged))
            {
                var damageApplied = damaged.PreviewDamage(damage);
                _eventBus.RegisterEvent("HIT", new { doer = attacker.Type, doee = victim.Type, damage = damageApplied });
                damaged.ApplyDamage(damage);
            }
            else
            {
                _eventBus.RegisterEvent("HIT_NO_DAM", new { doer = attacker.Type, doee = victim.Type });
            }
        }
    }
}
