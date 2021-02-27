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
        public IDictionary<string, object> Values;

        public GCEvent(string id, IDictionary<string, object> values)
        {
            Id = id;
            Values = values;
        }
    }
}
