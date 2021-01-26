using GunCleric.Atoms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Atoms
{
    public class UniqueAtomComponent : IAtomComponent
    {
        public Atom MyAtom { get; }

        public string Name { get; }

        public UniqueAtomComponent(Atom atom, string name)
        {
            MyAtom = atom;
            Name = name;
        }

        public Type GetComponentInterface() => typeof(UniqueAtomComponent);
    }
}
