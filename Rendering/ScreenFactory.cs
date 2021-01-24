using GunCleric.Game;

namespace GunCleric.Rendering
{
    public static class ScreenFactory
    {
        public static Screen GetMainScreen(GameState gameState)
        {
            var displayFields = new []
            {
                new DisplayField(2, 22, () => gameState.PlayerName),
                new DisplayField(2, 23, () => $"Health: {gameState.Hp}%"),
                new DisplayField(15, 23, () => $"Exp: {gameState.Xp}"),
                new DisplayField(29, 22, () => $"Armour: {gameState.Armour}"),
                new DisplayField(29, 23, () => $"Weapon: {gameState.Weapon}")
            };

            var viewports = new []
            {
                new Viewport(new System.Drawing.Rectangle(1, 3, 78, 17))
            };

            var mainScreen = new Screen(displayFields, viewports);
            return mainScreen;
        }
    }
}