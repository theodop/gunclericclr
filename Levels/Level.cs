using GunCleric.Atoms;
using GunCleric.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Levels
{
    public class Level
    {
        public int LevelNumber { get; }

        public IDictionary<(int, int, Layer), Atom> LevelElements =
            new Dictionary<(int, int, Layer), Atom>();

        public Level(int levelNumber)
        {
            LevelNumber = levelNumber;
        }

        internal void AddLevelElement(Atom atom)
        {
            LevelElements[(atom.Position.X, atom.Position.Y, atom.Position.Layer)] = atom;
        }

        internal void UpdateLevelElement(GamePosition oldPosition, Atom atom)
        {
            var newKey = (atom.Position.X, atom.Position.Y, atom.Position.Layer);
            if (LevelElements.ContainsKey(newKey))
            {
                throw new Exception("Already something in this position");
            }

            LevelElements.Remove((oldPosition.X, oldPosition.Y, oldPosition.Layer));
            AddLevelElement(atom);
        }
    }
}
