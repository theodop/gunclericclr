using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Events
{
    public class GCEvent
    {
        public string Id;
        public object Values;

        public GCEvent(string id, object values)
        {
            Id = id;
            Values = values;
        }
    }
}
