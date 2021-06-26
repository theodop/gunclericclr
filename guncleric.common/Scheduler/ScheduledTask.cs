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
        public bool SuspendControl;
        public Action<ScheduledTask> Task;

        public bool Reschedule { get; internal set; }

        public int CompareTo(ScheduledTask other)
        {
            return EndTime.CompareTo(other.EndTime);
        }
    }
}
