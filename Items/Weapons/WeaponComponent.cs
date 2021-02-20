using GunCleric.Atoms;
using System;

namespace GunCleric.Items.Weapons
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
