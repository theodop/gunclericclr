using GunCleric.Atoms;
using GunCleric.Game;
using GunCleric.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Screens
{
    public class MainScreenInputActionController : IInputActionController
    {
        public Atom Atom { get; set; }

        public Type GetComponentInterface() => throw new NotImplementedException();

        public void ReactToAction(InputAction action, GameState gameState)
        {
            if (ActionIsForPlayer(action))
            {
                var playerInputController = gameState.Player.GetComponent<IInputActionController>();

                playerInputController.ReactToAction(action, gameState);
            }
        }

        private bool ActionIsForPlayer(InputAction action)
        {
            return true;
        }
    }
}
