using GunCleric.Atoms;
using System;

namespace GunCleric.Agents
{
    public class AgentComponent : IAtomComponent
    {
        public AgentComponent(Atom atom)
        {
            Atom = atom;
        }

        public Atom Atom { get; private set; }

        public Type GetComponentInterface() => typeof(AgentComponent);

        public AgentAttitude GetAttitudeToAgent(AgentComponent agent)
        {
            return AgentAttitude.Foe;
        }
    }
}
