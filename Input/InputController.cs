using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Input
{
    public class InputController
    {
        public ConsoleKeyInfo GetConsoleInput()
        {
            return Console.ReadKey(intercept: true);
        }

        public InputAction GetActionFromInput(ConsoleKeyInfo keyInfo)
        {
            return keyInfo.Key switch
            {
                ConsoleKey.W    => InputAction.MoveUp,
                ConsoleKey.E    => InputAction.MoveUpRight,
                ConsoleKey.D    => InputAction.MoveRight,
                ConsoleKey.C    => InputAction.MoveDownRight,
                ConsoleKey.X    => InputAction.MoveDown,
                ConsoleKey.Z    => InputAction.MoveDownLeft,
                ConsoleKey.A    => InputAction.MoveLeft,
                ConsoleKey.Q    => InputAction.MoveUpLeft,
                ConsoleKey.G    => InputAction.PickUp,
                _               => InputAction.None
            };
        }
    }
}
