using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            return keyInfo.KeyChar switch
            {
                'w'    => InputAction.MoveUp,
                'e'    => InputAction.MoveUpRight,
                'd'    => InputAction.MoveRight,
                'c'    => InputAction.MoveDownRight,
                'x'    => InputAction.MoveDown,
                'z'    => InputAction.MoveDownLeft,
                'a'    => InputAction.MoveLeft,
                'q'    => InputAction.MoveUpLeft,
                'g'    => InputAction.PickUp,
                's'    => InputAction.Wait,
                _      => InputAction.None
            };
        }
    }
}
