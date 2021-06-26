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
                new DisplayField(2, 21, 50, () => gameState.CurrentTime.ToString("yyyy-MM-dd HH:mm:ss.fff")),
                new DisplayField(2, 22, 25, () => player.GetComponent<UniqueAtomComponent>().Name),
                new DisplayField(2, 23, 11, () => $"Health: {gameState.Hp}%"),
                new DisplayField(15, 23, 12, () => $"Exp: {gameState.Xp}"),
                new DisplayField(29, 22, 25, () => $"Armour: {gameState.Armour}"),
                new DisplayField(29, 23, 25, () => $"Weapon: {gameState.Weapon}"),
                new DisplayField(2, 1, 40, () => _eventKeeper.GetLatestEventString())
            };

            var viewports = new []
            {
                new Viewport(new System.Drawing.Rectangle(1, 3, 78, 17), gameState.Player)
            };

            var mainScreen = new Screen(displayFields, viewports, new MainScreenInputActionController());
            return mainScreen;
        }
    }
}