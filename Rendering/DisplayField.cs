using System;
using System.Diagnostics.CodeAnalysis;

namespace GunCleric.Rendering
{
    public class DisplayField
    {
        public int X {get;}
        public int Y {get;}

        [NotNull]
        public Func<string> GetValue {get;}

        public DisplayField(int x, int y, Func<string> getFunc)
        {
            X = x;
            Y = y;
            GetValue = getFunc;
        }
    }
}