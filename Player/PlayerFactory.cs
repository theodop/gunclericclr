using GunCleric.Atoms;
using GunCleric.Geometry;
using GunCleric.Items;
using GunCleric.Levels;

namespace GunCleric.Player
{
    public static class PlayerFactory
    {
        public static Atom CreatePlayer(string name, GamePosition position, LevelController levelController)
        {
            var player = new Atom("Player", '@', position);
            var inputActionController = new PlayerInputActionController(player);
            player.AddComponent(inputActionController);
            var uniqueComponent = new UniqueAtomComponent(player, name);
            player.AddComponent(uniqueComponent);
            var inventoryComponent = new InventoryComponent(player, levelController);
            player.AddComponent(inventoryComponent);
            return player;
        }
    }
}