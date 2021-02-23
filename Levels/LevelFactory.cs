using GunCleric.Atoms;
using GunCleric.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Levels
{
    public class LevelFactory
    {
        public Level GenerateLevel(int levelNumber)
        {
            var level = new Level(levelNumber);

            var room = GenerateRoom(0, 0, 50, 50, levelNumber);

            foreach (var atom in room)
            {
                level.AddLevelElement(atom);
            }

            return level;
        }

        private static IEnumerable<Atom> GenerateRoom(int left, int top, int width, int height, int level)
        {
            var right = left + width - 1;
            var bottom = top + height - 1;
            yield return GenerateWall(CardinalDirection.TopLeft, left, top, level);
            yield return GenerateWall(CardinalDirection.TopRight, right, top, level);
            yield return GenerateWall(CardinalDirection.BottomLeft, left, bottom, level);
            yield return GenerateWall(CardinalDirection.BottomRight, right, bottom, level);

            for (int x = left + 1; x < right; x++)
            {
                yield return GenerateWall(CardinalDirection.Top, x, top, level);
                yield return GenerateWall(CardinalDirection.Bottom, x, bottom, level);
            }
            for (int y = top + 1; y < bottom; y++)
            {
                yield return GenerateWall(CardinalDirection.Left, left, y, level);
                yield return GenerateWall(CardinalDirection.Right, right, y, level);
            }

            for (int x = left + 1; x < right; x++)
            {
                for (int y = top + 1; y < bottom; y++)
                {
                    yield return new Atom("Floor", '.', new GamePosition(x, y, level, Layer.Floor));
                }
            }
        }

        private static Atom GenerateWall(CardinalDirection dir, int x, int y, int level)
        {
            char tile = dir switch
            {
                CardinalDirection.TopLeft => '╔',
                CardinalDirection.TopRight => '╗',
                CardinalDirection.BottomLeft => '╚',
                CardinalDirection.BottomRight => '╝',
                CardinalDirection.Left => '║',
                CardinalDirection.Right => '║',
                CardinalDirection.Top => '═',
                CardinalDirection.Bottom => '═'
            };

            return new Atom("Wall", tile, new GamePosition(x, y, level, Layer.Blocking));
        }
    }
}
