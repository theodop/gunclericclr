using GunCleric.Agents;
using GunCleric.Atoms;
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
        public Atom CreateEnemy(string type, GamePosition position)
        {
            var tile = type switch
            {
                "Mook" => 'm'
            };

            var enemy = new Atom(type, tile, position);
            enemy.AddComponent(new AgentComponent(enemy));

            return enemy;
        }
    }
}
