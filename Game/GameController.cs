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
        private readonly LevelController _levelController;
        private readonly LevelFactory _levelFactory;
        private readonly ItemFactory _itemFactory;
        private readonly ScreenFactory _screenFactory;
        private readonly PlayerFactory _playerFactory;

        public GameController(RenderController renderController, 
            InputController inputController,
            SaveController saveController,
            LevelController levelController,
            LevelFactory levelFactory,
            ItemFactory itemFactory,
            ScreenFactory screenFactory,
            PlayerFactory playerFactory
            )
        {
            _renderController = renderController;
            _inputController = inputController;
            _saveController = saveController;
            _levelController = levelController;
            _levelFactory = levelFactory;
            _itemFactory = itemFactory;
            _screenFactory = screenFactory;
            _playerFactory = playerFactory;
        }

        public void Start()
        {
            var gameState = new GameState();

            gameState.Player = _playerFactory.CreatePlayer("Bungus", new GamePosition(5, 5, 1, Layer.Blocking));

            var level = _levelFactory.GenerateLevel(1);
            level.AddLevelElement(gameState.Player);

            var testItem1 = _itemFactory.CreateItem("katana", new GamePosition(7, 7, 1, Layer.OnFloor));
            var testItem2 = _itemFactory.CreateItem("katana", new GamePosition(4, 9, 1, Layer.OnFloor));

            level.AddLevelElement(testItem1, Level.AddStyle.Stack);
            level.AddLevelElement(testItem2, Level.AddStyle.Stack);

            gameState.Levels[1] = level;
            gameState.CurrentLevel = level;

            var mainScreen = _screenFactory.GetMainScreen(gameState);

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