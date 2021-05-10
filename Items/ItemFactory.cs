using GunCleric.Atoms;
using GunCleric.Geometry;
using GunCleric.Rendering;
using System;
using System.Collections.Generic;
using System.Drawing;
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
                "katana" => new ColouredChar(')',Color.Blue),
                _        => new ColouredChar('?')
            };

            return new Atom(type, tile, gamePosition);
        }
    }
}
