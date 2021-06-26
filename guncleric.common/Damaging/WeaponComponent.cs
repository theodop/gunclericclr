using GunCleric.Atoms;
using GunCleric.Items.Weapons;
using System;

namespace GunCleric.Damaging
{
    public class WeaponComponent : IAtomComponent
    {
        public Atom Atom { get; }
        public WeaponType WeaponType { get; }
        public Damage Damage { get; }

        public Type GetComponentInterface() => typeof(WeaponComponent);

        public WeaponComponent(Atom atom, WeaponType weaponType, Damage damage)
        {
            Atom = atom;
            WeaponType = weaponType;
            Damage = damage;
        }
    }
}
