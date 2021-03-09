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

        private PlayerInteractionComponent _interactionComponent;

        public PlayerInputActionController(Atom atom, PlayerInteractionComponent interactionComponent)
        {
            Atom = atom;
            _interactionComponent = interactionComponent;
        }

        public Type GetComponentInterface() => typeof(IInputActionController);

        public void ReactToAction(InputAction action, GameState gameState)
        {
            if (MovementActions.Contains(action)) ReactToMovement(action, gameState);
            else if (InventoryActions.Contains(action)) ReactToInventory(action, gameState);
        }

        private void ReactToMovement(InputAction action, GameState gameState)
        {
            var direction = action switch
            {
                InputAction.MoveUp => CardinalDirection.Top,
                InputAction.MoveUpRight => CardinalDirection.TopRight,
                InputAction.MoveRight => CardinalDirection.Right,
                InputAction.MoveDownRight => CardinalDirection.BottomRight,
                InputAction.MoveDown => CardinalDirection.Bottom,
                InputAction.MoveDownLeft => CardinalDirection.BottomLeft,
                InputAction.MoveLeft => CardinalDirection.Left,
                InputAction.MoveUpLeft => CardinalDirection.TopLeft,
                _ => throw new NotImplementedException()
            };

            _interactionComponent.InteractWith(direction, gameState);
        }

        private void ReactToInventory(InputAction action, GameState gameState)
        {
            var inventoryComponent = Atom.GetComponent<InventoryComponent>();
            inventoryComponent.PickUp(gameState);
        }
    }
}
