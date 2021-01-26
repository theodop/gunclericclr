using GunCleric.Atoms;
using GunCleric.Geometry;

namespace GunCleric.Player
{
    public static class PlayerFactory
    {
        public static Atom CreatePlayer(string name, GamePosition position)
        {
            var player = new Atom("Player", '@', position);
            var inputActionController = new PlayerInputActionController(player);
            player.AddComponent(inputActionController);
            return player;
        }
    }
}