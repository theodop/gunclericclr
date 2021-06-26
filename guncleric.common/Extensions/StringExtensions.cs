using GunCleric.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Extensions
{
    public static class StringExtensions
    {
        public static ColouredChar[] ToColouredCharArray(this string s)
        {
            return s.ToCharArray().Select(c => new ColouredChar(c)).ToArray();
        }
    }
}
