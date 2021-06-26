using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Events
{
    public class EventBus
    {
        private ICollection<IEventListener> _listeners = new List<IEventListener>();

        public void AddListener(IEventListener listener)
        {
            _listeners.Add(listener);
        }

        public void RegisterEvent(GCEvent gcEvent)
        {
            foreach (var listener in _listeners)
            {
                listener.GiveMeAnEvent(gcEvent);
            }
        }

        public void RegisterEvent(string id, object values = null)
        {
            RegisterEvent(new GCEvent(id, values));
        }
    }
}
