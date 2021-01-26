using System;
using System.Drawing;
using GunCleric.Input;
using GunCleric.Player;
using GunCleric.Rendering;

namespace GunCleric.Game
{
    public class GameController
    {
        private readonly RenderController _renderController;
        private readonly InputController _inputController;

        public GameController(RenderController renderController, InputController inputController)
        {
            _renderController = renderController;
            _inputController = inputController;
        }

        public void Start()
        {
            var gameState = new GameState();

            var mainScreen = ScreenFactory.GetMainScreen(gameState);

            gameState.CurrentScreen = mainScreen;

            gameState.Player = PlayerFactory.CreatePlayer("Player", new Geometry.GamePosition(5, 5, 1));

            _renderController.Initialise(gameState);

            Loop(gameState);
        }

        private void Loop(GameState gameState)
        {
            while (true)
            {
                Render(gameState);
                Update(gameState);
            }
        }

        private void Render(GameState gameState)
        {
            _renderController.Render(gameState);
        }

        private void Update(GameState gameState)
        {
            var input = _inputController.GetConsoleInput();
            var action = _inputController.GetActionFromInput(input);

            gameState.CurrentScreen.ScreenActionController.ReactToAction(action, gameState);
        }
    }
}