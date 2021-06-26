using GunCleric.Input;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GunCleric.Rendering
{
    [DataContract]
    public class Screen
    {
        public ICollection<DisplayField> DisplayFields;
        [DataMember]
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