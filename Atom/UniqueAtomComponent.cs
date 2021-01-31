using GunCleric.Atoms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Atoms
{
    [DataContract]
    public class UniqueAtomComponent : IAtomComponent
    {
        public Atom Atom { get; set; }

        [DataMember]
        public string Name;

        public UniqueAtomComponent(Atom atom, string name)
        {
            Atom = atom;
            Name = name;
        }

        public Type GetComponentInterface() => typeof(UniqueAtomComponent);
    }
}
