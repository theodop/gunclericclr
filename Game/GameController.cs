using System;
using System.Drawing;
using GunCleric.Geometry;
using GunCleric.Input;
using GunCleric.Items;
using GunCleric.Levels;
using GunCleric.Player;
using GunCleric.Rendering;
using GunCleric.Saving;

namespace GunCleric.Game
{
    public class GameController
    {
        private readonly RenderController _renderController;
        private readonly InputController _inputController;
        private readonly SaveController _saveController;

        public GameController(RenderController renderController, 
            InputController inputController,
            SaveController saveController)
        {
            _renderController = renderController;
            _inputController = inputController;
            _saveController = saveController;
        }

        public void Start()
        {
            var gameState = new GameState();

            gameState.Player = PlayerFactory.CreatePlayer("Bungus", new GamePosition(5, 5, 1, Layer.Blocking));

            var level = LevelFactory.GenerateLevel(1);
            level.AddLevelElement(gameState.Player);

            var testItem1 = ItemFactory.CreateItem("katana", new GamePosition(7, 7, 1, Layer.OnFloor));
            var testItem2 = ItemFactory.CreateItem("katana", new GamePosition(4, 9, 1, Layer.OnFloor));

            level.AddLevelElement(testItem1, Level.AddStyle.Stack);
            level.AddLevelElement(testItem2, Level.AddStyle.Stack);

            gameState.Levels[1] = level;
            gameState.CurrentLevel = level;

            var mainScreen = ScreenFactory.GetMainScreen(gameState);

            gameState.CurrentScreen = mainScreen;

            _renderController.Initialise(gameState);

            Loop(gameState);
        }

        private void Loop(GameState gameState)
        {
            while (true)
            {
                Render(gameState);
                Update(gameState);
                _saveController.Save(gameState);
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