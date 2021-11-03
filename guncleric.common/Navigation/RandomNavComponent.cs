using GunCleric.Atoms;
using GunCleric.Game;
using GunCleric.Geometry;
using GunCleric.Random;
using GunCleric.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Navigation
{
    public class RandomNavComponent : IAtomComponent
    {
        public Atom Atom { get; private set; }

        private readonly ScheduleController _scheduleController;
        private readonly Randomiser _rand;
        private readonly uint _speedMs;

        public RandomNavComponent(Atom atom, Randomiser rand, ScheduleController scheduleController, 
            uint speedMs, GameState gameState)
        {
            Atom = atom;
            _scheduleController = scheduleController;
            _rand = rand;
            _speedMs = speedMs;

            _scheduleController.Schedule(t => Roam(gameState), speedMs, gameState, reschedule: true);
        }

        private void Roam(GameState gameState)
        {
            var direction = _rand.UniformBetween(0, 4) switch
            {
                0 => CardinalDirection.Top,
                1 => CardinalDirection.Right,
                2 => CardinalDirection.Bottom,
                3 => CardinalDirection.Left
            };

            Atom.MoveAtom(Atom.Position.GetRelativePosition(direction), gameState);
        }

        public Type GetComponentInterface() => typeof(RandomNavComponent);
    }
}
