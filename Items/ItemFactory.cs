using GunCleric.Atoms;
using GunCleric.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Items
{
    public class ItemFactory
    {
        public Atom CreateItem(string type, GamePosition gamePosition)
        {
            var tile = type switch
            {
                "katana" => ')',
                _        => '?'
            };

            return new Atom(type, tile, gamePosition);
        }
    }
}
