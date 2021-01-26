using GunCleric.Input;
using System.Collections.Generic;

namespace GunCleric.Rendering
{
    public class Screen
    {
        public ICollection<DisplayField> DisplayFields;
        public ICollection<Viewport> Viewports;
        public IInputActionController ScreenActionController;

        public Screen(ICollection<DisplayField> displayFields, ICollection<Viewport> viewports,
            IInputActionController screenActionController)
        {
            DisplayFields = displayFields;
            Viewports = viewports;
            ScreenActionController = screenActionController;
        }
    }
}