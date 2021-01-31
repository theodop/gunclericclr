using System;

namespace GunCleric.Atoms
{
    public interface IAtomComponent
    {
        Atom Atom { get; set; }
        Type GetComponentInterface();
    }
}