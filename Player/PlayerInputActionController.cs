using GunCleric.Atoms;
using GunCleric.Game;
using GunCleric.Geometry;
using GunCleric.Input;
using GunCleric.Items;
using GunCleric.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Player
{
    public class PlayerInputActionController : IInputActionController
    {
        private static readonly HashSet<InputAction> MovementActions = new HashSet<InputAction>
        {
            InputAction.MoveUp,
            InputAction.MoveUpRight,
            InputAction.MoveRight,
            InputAction.MoveDownRight,
            InputAction.MoveDown,
            InputAction.MoveDownLeft,
            InputAction.MoveLeft,
            InputAction.MoveUpLeft
        };

        private static readonly HashSet<InputAction> InventoryActions = new HashSet<InputAction>
        {
            InputAction.PickUp,
            InputAction.PutDown
        };

        public Atom Atom { get; set; }

        public PlayerInputActionController(Atom atom)
        {
            Atom = atom;
        }

        public Type GetComponentInterface() => typeof(IInputActionController);

        public void ReactToAction(InputAction action, GameState gameState)
        {
            if (MovementActions.Contains(action)) ReactToMovement(action, gameState);
            else if (InventoryActions.Contains(action)) ReactToInventory(action, gameState);
        }

        private void ReactToMovement(InputAction action, GameState gameState)
        {
            var player = Atom;

            (var x, var y) = action switch
            {
                InputAction.MoveUp => (player.Position.X, player.Position.Y - 1),
                InputAction.MoveUpRight => (player.Position.X + 1, player.Position.Y - 1),
                InputAction.MoveRight => (player.Position.X + 1, player.Position.Y),
                InputAction.MoveDownRight => (player.Position.X + 1, player.Position.Y + 1),
                InputAction.MoveDown => (player.Position.X, player.Position.Y + 1),
                InputAction.MoveDownLeft => (player.Position.X - 1, player.Position.Y + 1),
                InputAction.MoveLeft => (player.Position.X - 1, player.Position.Y),
                InputAction.MoveUpLeft => (player.Position.X - 1, player.Position.Y - 1),
                _ => (player.Position.X, player.Position.Y)
            };

            var newPosition = new GamePosition(x, y, player.Position.Level, player.Position.Layer);

            player.MoveAtom(newPosition, gameState);
        }

        private void ReactToInventory(InputAction action, GameState gameState)
        {
            var inventoryComponent = Atom.GetComponent<InventoryComponent>();
            inventoryComponent.PickUp(gameState);
        }
    }
}
