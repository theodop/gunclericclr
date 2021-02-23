using System;
using GunCleric.Game;
using GunCleric.Input;
using GunCleric.Items;
using GunCleric.Levels;
using GunCleric.Player;
using GunCleric.Rendering;
using GunCleric.Saving;

namespace GunCleric
{
    class Program
    {
        static void Main(string[] args)
        {
            var renderController = new RenderController();
            var inputController = new InputController();
            var saveController = new SaveController();
            var levelController = new LevelController();
            var levelFactory = new LevelFactory();
            var itemFactory = new ItemFactory();
            var screenFactory = new ScreenFactory();
            var playerFactory = new PlayerFactory(levelController);

            var gameController = new GameController(
                renderController,
                inputController,
                saveController,
                levelController,
                levelFactory,
                itemFactory,
                screenFactory,
                playerFactory
            );

            gameController.Start();
        }
    }
}
