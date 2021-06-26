using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Rendering
{
    public class ColouredString
    {
        public readonly ColouredChar[] ColouredChars;

        public int Length => ColouredChars.Length;

        public override string ToString()
        {
            return new string(ColouredChars.Select(x => x.Char).ToArray());
        }
    }
}
