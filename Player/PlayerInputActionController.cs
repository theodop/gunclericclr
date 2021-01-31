using GunCleric.Atoms;
using GunCleric.Game;
using GunCleric.Geometry;
using GunCleric.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Player
{
    public class PlayerInputActionController : IInputActionController
    {
        public Atom Atom { get; set; }

        public PlayerInputActionController(Atom atom)
        {
            Atom = atom;
        }

        public Type GetComponentInterface() => typeof(IInputActionController);

        public void ReactToAction(InputAction action, GameState gameState)
        {
            var player = Atom;

            (var x, var y) = action switch
            {
                InputAction.MoveUp          => (player.Position.X, player.Position.Y - 1),
                InputAction.MoveUpRight     => (player.Position.X + 1, player.Position.Y - 1),
                InputAction.MoveRight       => (player.Position.X + 1, player.Position.Y),
                InputAction.MoveDownRight   => (player.Position.X + 1, player.Position.Y + 1),
                InputAction.MoveDown        => (player.Position.X, player.Position.Y + 1),
                InputAction.MoveDownLeft    => (player.Position.X - 1, player.Position.Y + 1),
                InputAction.MoveLeft        => (player.Position.X - 1, player.Position.Y),
                InputAction.MoveUpLeft      => (player.Position.X - 1, player.Position.Y - 1),
                _                           => (player.Position.X, player.Position.Y)
            };

            player.Position = new GamePosition(x, y, player.Position.Level);
        }
    }
}
