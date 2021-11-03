using GunCleric.Atoms;
using GunCleric.Game;
using GunCleric.Geometry;
using GunCleric.Navigation;
using GunCleric.Random;
using GunCleric.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Navigation
{
    public class DirectNavComponent : INavComponent
    {

        private readonly ScheduleController _scheduleController;
        private readonly int _speedMs;


        public DirectNavComponent(Atom atom, ScheduleController scheduleController, int speedMs)
        {
            Atom = atom;
            _scheduleController = scheduleController;
            _speedMs = speedMs;
        }

        public Atom Atom {get; private set;}

        public Type GetComponentInterface() => typeof(INavComponent);

        public void NavigateTowards(GamePosition target, GameState gameState)
        {
            var distance = Atom.Position.DistanceTo(target);
            Atom.MoveAtom(distance.GetCardinalDirection(), gameState);
        }
    }
}