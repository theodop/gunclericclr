using GunCleric.Levels;

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
    }
}