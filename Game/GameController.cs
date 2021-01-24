using System;
using System.Drawing;
using GunCleric.Controllers;
using GunCleric.Rendering;

namespace GunCleric.Game
{
    public class GameController
    {
        private readonly RenderController _renderController;

        public GameController(RenderController renderController)
        {
            _renderController = renderController;
        }

        public void Start()
        {
            var gameState = new GameState();

            var mainScreen = ScreenFactory.GetMainScreen(gameState);

            gameState.CurrentScreen = mainScreen;

            _renderController.Initialise(gameState);

            Loop(gameState);
        }

        private void Loop(GameState gameState)
        {
            while (true)
            {
                Update(gameState);
                Render(gameState);

                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.W)
                {
                    gameState.PlayerPosition = new Point(gameState.PlayerPosition.X, gameState.PlayerPosition.Y - 1);
                }
            }
        }

        private void Render(GameState gameState)
        {
            _renderController.Render(gameState);
        }

        private void Update(GameState gameState)
        {
        }
    }
}