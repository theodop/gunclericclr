using GunCleric.Game;
using GunCleric.Atoms;

namespace GunCleric.Input
{
    public interface IInputActionController : IAtomComponent
    {
        void ReactToAction(InputAction action, GameState gameState);
    }
}
