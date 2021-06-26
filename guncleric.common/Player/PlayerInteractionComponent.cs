using GunCleric.Agents;
using GunCleric.Atoms;
using GunCleric.Damaging;
using GunCleric.Game;
using GunCleric.Geometry;
using GunCleric.Levels;
using GunCleric.Random;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Player
{
    public class PlayerInteractionComponent : IAtomComponent
    {
        public Atom Atom { get; }

        private readonly LevelController _levelController;
        private readonly DamagerComponent _damager;
        private readonly Randomiser _random;

        public Type GetComponentInterface() => typeof(PlayerInteractionComponent);

        public PlayerInteractionComponent(Atom atom, LevelController levelController, 
            DamagerComponent damager, Randomiser random)
        {
            Atom = atom;
            _levelController = levelController;
            _damager = damager;
            _random = random;
        }

        public void InteractWith(CardinalDirection direction, GameState gameState)
        {
            var posOfInterest = Atom.Position.GetRelativePosition(direction);

            var atoms = _levelController.GetAtoms(posOfInterest, gameState);

            // if there are any enemies in this square, attack them
            var enemy = atoms.FirstOrDefault(x => x.HasComponent<AgentComponent>());

            if (enemy != null)
            {
                _damager.Damage(Atom, enemy, new Damage { Impact = 10, Piercing = 0 });
            }
            else
            {
                Atom.MoveAtom(posOfInterest, gameState);
            }
        }
    }
}
