using GunCleric.Agents;
using GunCleric.Atoms;
using GunCleric.Damaging;
using GunCleric.Events;
using GunCleric.Geometry;
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

        public EnemyFactory(EventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public Atom CreateEnemy(string type, GamePosition position)
        {
            var tile = type switch
            {
                "Mook" => 'm'
            };

            var enemy = new Atom(type, tile, position);
            enemy.AddComponent(new AgentComponent(enemy));
            var damagedComponent = new DamagedComponent(enemy, _eventBus);
            enemy.AddComponent(damagedComponent);

            return enemy;
        }
    }
}
