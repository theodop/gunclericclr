using GunCleric.Atoms;
using GunCleric.Geometry;

namespace GunCleric.Player
{
    public static class PlayerFactory
    {
        public static Atom CreatePlayer(string name, GamePosition position)
        {
            return new Atom("Player", '@', position);
        }
    }
}