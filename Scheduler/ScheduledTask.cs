using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Scheduler
{
    public class ScheduledTask : IComparable<ScheduledTask>
    {
        public DateTime StartTime;
        public DateTime EndTime;
        public bool ReturnControl;
        public Action<ScheduledTask> Task;

        public int CompareTo(ScheduledTask other)
        {
            return EndTime.CompareTo(other.EndTime);
        }
    }
}
