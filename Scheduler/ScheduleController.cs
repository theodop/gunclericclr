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
            bool returnControl = false)
        {
            var scheduledTask = new ScheduledTask
            {
                Task = task,
                StartTime = gameState.CurrentTime,
                EndTime = gameState.CurrentTime.AddMilliseconds(completionMs),
                ReturnControl = returnControl
            };

            gameState.Schedule.Push(scheduledTask);
        }
    }
}
