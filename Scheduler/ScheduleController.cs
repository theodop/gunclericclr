using GunCleric.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Scheduler
{
    public class ScheduleController
    {
        public void Schedule(Action<ScheduledTask> task, uint completionMs, GameState gameState, 
            bool suspendControl = false, bool reschedule = false)
        {
            var scheduledTask = new ScheduledTask
            {
                Task = task,
                StartTime = gameState.CurrentTime,
                EndTime = gameState.CurrentTime.AddMilliseconds(completionMs),
                SuspendControl = suspendControl,
                Reschedule = reschedule
            };

            if (suspendControl) gameState.Schedule.SuspendControl = true;

            gameState.Schedule.Push(scheduledTask);
        }

        internal void Reschedule(ScheduledTask task, GameState gameState)
        {
            Schedule(task.Task, (uint)(task.EndTime - task.StartTime).TotalMilliseconds, gameState, task.SuspendControl, task.Reschedule);
        }

        public void Run(ScheduledTask task, GameState gameState)
        {
            gameState.CurrentTime = task.EndTime;

            task.Task(task);

            if (task.SuspendControl) gameState.Schedule.SuspendControl = false;

            if (task.Reschedule) Reschedule(task, gameState);
        }

        internal void RunUntilUnsuspended(GameState gameState)
        {
            while (true)
            {
                var task = gameState.Schedule.Pop();

                if (task != null)
                {
                    Run(task, gameState);
                }

                if (task == null || task.SuspendControl) break;
            }
        }
    }
}
