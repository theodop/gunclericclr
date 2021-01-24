using System.Drawing;

namespace GunCleric.Rendering
{
    public class Viewport
    {
        public Viewport(Rectangle area)
        {
            Area = area;
        }

        public Rectangle Area;
    }
}