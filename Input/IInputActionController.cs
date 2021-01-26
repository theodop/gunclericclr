using GunCleric.Game;
using GunCleric.Atoms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Input
{
    public interface IInputActionController : IAtomComponent
    {
        void ReactToAction(InputAction action, GameState gameState);
    }
}
