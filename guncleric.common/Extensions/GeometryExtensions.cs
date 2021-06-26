using System.Drawing;

namespace GunCleric.Extensions
{
    public static class GeometryExtensions
    {
        public static bool Intersect(this Rectangle rect, int x, int y)
        {
            return x >= rect.Left &&
                   x < rect.Left + rect.Width &&
                   y >= rect.Top &&
                   y < rect.Top + rect.Height;
        }
    }
}