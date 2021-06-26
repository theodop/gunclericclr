using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Scheduler
{
    public class Schedule : IEnumerable<ScheduledTask>
    {
        private SortedSet<ScheduledTask> _tasks = new SortedSet<ScheduledTask>();
        internal bool SuspendControl;

        public IEnumerator<ScheduledTask> GetEnumerator() => _tasks.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Push(ScheduledTask task)
        {
            while (_tasks.Contains(task))
            {
                task.EndTime = task.EndTime.AddTicks(1);
            }

            _tasks.Add(task);
        }

        internal ScheduledTask Pop()
        {
            if (_tasks.Any())
            {
                var task = _tasks.First();
                _tasks.Remove(task);
                return task;
            }
            return null;
        }
    }
}
