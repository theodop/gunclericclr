using System;

namespace GunCleric.Atoms
{
    public interface IAtomComponent
    {
        Type GetComponentInterface();

        Atom MyAtom { get; }
    }
}