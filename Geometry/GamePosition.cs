namespace GunCleric.Geometry
{
    public struct GamePosition
    {
        public GamePosition(int x, int y, int level)
        {
            X = x;
            Y = y;
            Level = level;
        }

        public int X { get; }
        public int Y { get; }
        public int Level { get; }
    }
}