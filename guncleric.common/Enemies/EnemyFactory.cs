using GunCleric.Agents;
using GunCleric.Atoms;
using GunCleric.Damaging;
using GunCleric.Events;
using GunCleric.Game;
using GunCleric.Geometry;
using GunCleric.Navigation;
using GunCleric.Random;
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
        private readonly Randomiser _rand;
        private readonly ScheduleController _scheduleController;

        public EnemyFactory(EventBus eventBus, Randomiser rand, ScheduleController scheduleController)
        {
            _eventBus = eventBus;
            _rand = rand;
            _scheduleController = scheduleController;
        }

        public Atom CreateEnemy(string type, GamePosition position, GameState gameState)
        {
            var tile = type switch
            {
                "Mook" => 'm',
                "Holy Waste" => 'h'
            };

            var enemy = new Atom(type, tile, position);
            enemy.AddComponent(new AgentComponent(enemy));
            var damagedComponent = new DamagedComponent(enemy, _eventBus, _rand);
            enemy.AddComponent(damagedComponent);
            // var navComponent = new RandomNavComponent(enemy, _rand, _scheduleController, 2013, gameState);
            var navComponent = new DirectNavComponent(enemy, _scheduleController, 2013);
            enemy.AddComponent(navComponent);

            return enemy;
        }
    }
}
