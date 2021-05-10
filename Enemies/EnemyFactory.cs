using GunCleric.Agents;
using GunCleric.Atoms;
using GunCleric.Damaging;
using GunCleric.Events;
using GunCleric.Game;
using GunCleric.Geometry;
using GunCleric.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Enemies
{
    public class EnemyFactory
    {
        private readonly EventBus _eventBus;
        private readonly Random _rand;
        private readonly ScheduleController _scheduleController;

        public EnemyFactory(EventBus eventBus, Random rand, ScheduleController scheduleController)
        {
            _eventBus = eventBus;
            _rand = rand;
            _scheduleController = scheduleController;
        }

        public Atom CreateEnemy(string type, GamePosition position, GameState gameState)
        {
            var tile = type switch
            {
                "Mook" => 'm'
            };

            var enemy = new Atom(type, tile, position);
            enemy.AddComponent(new AgentComponent(enemy));
            var damagedComponent = new DamagedComponent(enemy, _eventBus);
            enemy.AddComponent(damagedComponent);
            var navComponent = new RandomNavComponent(enemy, _rand, _scheduleController, 2013, gameState);
            enemy.AddComponent(navComponent);

            return enemy;
        }
    }
}
