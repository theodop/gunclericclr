using GunCleric.Atoms;
using GunCleric.Geometry;
using GunCleric.Items;
using GunCleric.Levels;

namespace GunCleric.Player
{
    public class PlayerFactory
    {
        private readonly LevelController _levelController;

        public PlayerFactory(LevelController levelController)
        {
            _levelController = levelController;
        }

        public Atom CreatePlayer(string name, GamePosition position)
        {
            var player = new Atom("Player", '@', position);
            var inputActionController = new PlayerInputActionController(player);
            player.AddComponent(inputActionController);
            var uniqueComponent = new UniqueAtomComponent(player, name);
            player.AddComponent(uniqueComponent);
            var inventoryComponent = new InventoryComponent(player, _levelController);
            player.AddComponent(inventoryComponent);
            return player;
        }
    }
}