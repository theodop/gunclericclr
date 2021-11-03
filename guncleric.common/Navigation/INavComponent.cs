using GunCleric.Atoms;
using GunCleric.Game;
using GunCleric.Geometry;

namespace GunCleric.Navigation
{
    public interface INavComponent : IAtomComponent
    {
        void NavigateTowards(GamePosition position, GameState gameState);
    }
}