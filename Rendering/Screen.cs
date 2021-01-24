using System.Collections.Generic;

namespace GunCleric.Rendering
{
    public class Screen
    {
        public ICollection<DisplayField> DisplayFields;
        public ICollection<Viewport> Viewports;

        public Screen(ICollection<DisplayField> displayFields, ICollection<Viewport> viewports)
        {
            DisplayFields = displayFields;
            Viewports = viewports;
        }
    }
}