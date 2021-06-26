using GunCleric.Atoms;
using GunCleric.Game;
using GunCleric.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Levels
{
    public class LevelController
    {
        internal IEnumerable<Atom> GetAtoms(GamePosition position, GameState gameState)
        {
            var level = gameState.Levels[position.Level];

            return level.GetAtoms(position);
        }

        internal void RemoveLevelElement(Atom atom, GameState gameState)
        {
            var level = gameState.Levels[atom.Position.Level];

            level.RemoveLevelElement(atom.Position, atom);
        }
    }
}
