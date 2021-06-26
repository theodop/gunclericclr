using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Random
{
    public class Randomiser
    {
        private System.Random _rand;
        public Randomiser(System.Random rand)
        {
            _rand = rand;
        }

        public int GetBellCurve(int peak)
        {
            // use a 2d6 and then scale
            return (D(6) + D(6)) * peak / 7;
        }

        public int D(int d) => _rand.Next(6) + 1;

        internal int UniformBetween(int lower, int upper) 
            => (int)(lower + _rand.NextDouble() * (upper - lower));
    }
}
