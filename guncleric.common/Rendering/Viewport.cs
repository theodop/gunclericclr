using GunCleric.Atoms;
using System.Drawing;
using System.Runtime.Serialization;

namespace GunCleric.Rendering
{
    [DataContract]
    public class Viewport
    {
        public Viewport(Rectangle area, Atom atomToTrack)
        {
            Area = area;
            AtomToTrack = atomToTrack;
        }

        [DataMember]
        public Rectangle Area;

        public Atom AtomToTrack { get; }
    }
}