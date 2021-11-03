using GunCleric.Levels;
using System;

namespace GunCleric.Geometry
{
    public struct GamePosition
    {
        public GamePosition(int x, int y, int level, Layer layer)
        {
            X = x;
            Y = y;
            Level = level;
            Layer = layer;
        }

        public int X { get; }
        public int Y { get; }
        public int Level { get; }
        public Layer Layer { get; }

        public GamePosition GetRelativePosition(CardinalDirection direction, int moveBy = 1, Layer? layer = null)
        {
            var (delx, dely) = direction switch
            {
                CardinalDirection.Top => (0, -1),
                CardinalDirection.TopRight => (1, -1),
                CardinalDirection.Right => (1, 0),
                CardinalDirection.BottomRight => (1, 1),
                CardinalDirection.Bottom => (0, 1),
                CardinalDirection.BottomLeft => (-1, 1),
                CardinalDirection.Left => (-1, 0),
                CardinalDirection.TopLeft => (-1, -1),
                _ => throw new NotImplementedException()
            };

            delx *= moveBy;
            dely *= moveBy;

            return new GamePosition(X + delx, Y + dely, Level, layer ?? Layer);
        }

        public Vector2 DistanceTo(GamePosition that) => new(that.X - X, that.Y - Y);
    }
}