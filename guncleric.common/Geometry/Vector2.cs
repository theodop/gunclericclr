using System;

namespace GunCleric.Geometry
{
    public struct Vector2
    {
        public int X;
        public int Y;

        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public double Length()
        {
            return Math.Sqrt(X*X + Y*Y);
        }

        public CardinalDirection GetCardinalDirection()
        {
            if (X > 0) 
            {
                if (Y > 0) return CardinalDirection.TopRight;
                if (Y < 0) return CardinalDirection.BottomRight;
                return CardinalDirection.Right;
            }
            else if (X < 0)
            {
                if (Y > 0) return CardinalDirection.TopLeft;
                if (Y < 0) return CardinalDirection.BottomLeft;
                return CardinalDirection.Left;
            }
            else
            {
                if (Y > 0) return CardinalDirection.Top;
                if (Y < 0) return CardinalDirection.Bottom;
                return CardinalDirection.None;
            }
        }
    }
}