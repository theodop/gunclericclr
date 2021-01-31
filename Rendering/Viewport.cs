using System.Drawing;
using System.Runtime.Serialization;

namespace GunCleric.Rendering
{
    [DataContract]
    public class Viewport
    {
        public Viewport(Rectangle area)
        {
            Area = area;
        }

        [DataMember]
        public Rectangle Area;
    }
}