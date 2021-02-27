using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Events
{
    public interface IEventListener
    {
        public void GiveMeAnEvent(GCEvent gcEvent);
    }
}
