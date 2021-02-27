using GunCleric.Atoms;
using GunCleric.Events;
using GunCleric.Game;
using GunCleric.Screens;

namespace GunCleric.Rendering
{
    public class ScreenFactory
    {
        private readonly EventKeeper _eventKeeper;

        public ScreenFactory(EventKeeper eventKeeper)
        {
            _eventKeeper = eventKeeper;
        }

        public Screen GetMainScreen(GameState gameState)
        {
            var player = gameState.Player;
            var displayFields = new[]
            {
                new DisplayField(2, 22, () => player.GetComponent<UniqueAtomComponent>().Name),
                new DisplayField(2, 23, () => $"Health: {gameState.Hp}%"),
                new DisplayField(15, 23, () => $"Exp: {gameState.Xp}"),
                new DisplayField(29, 22, () => $"Armour: {gameState.Armour}"),
                new DisplayField(29, 23, () => $"Weapon: {gameState.Weapon}"),
                new DisplayField(2, 1, () => _eventKeeper.GetLatestEventString())
            };

            var viewports = new []
            {
                new Viewport(new System.Drawing.Rectangle(1, 3, 78, 17))
            };

            var mainScreen = new Screen(displayFields, viewports, new MainScreenInputActionController());
            return mainScreen;
        }
    }
}