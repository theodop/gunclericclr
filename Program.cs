using System;
using GunCleric.Assets;
using GunCleric.Enemies;
using GunCleric.Events;
using GunCleric.Game;
using GunCleric.Input;
using GunCleric.Items;
using GunCleric.Levels;
using GunCleric.Player;
using GunCleric.Rendering;
using GunCleric.Saving;
using GunCleric.Scheduler;

namespace GunCleric
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var scheduleController = new ScheduleController();
            var renderController = new RenderController();
            var inputController = new InputController();
            var saveController = new SaveController();
            var levelController = new LevelController();
            var levelFactory = new LevelFactory();
            var itemFactory = new ItemFactory();
            var stringFormatter = new StringFormatterSmartFormat();
            var assetBank = new AssetBank(stringFormatter);
            var eventBus = new EventBus();
            var eventKeeper = new EventKeeper(eventBus, assetBank);
            var screenFactory = new ScreenFactory(eventKeeper);
            var playerFactory = new PlayerFactory(levelController, eventBus, random, scheduleController);
            var enemyFactory = new EnemyFactory(eventBus);

            try
            {
                var gameController = new GameController(
                renderController,
                inputController,
                saveController,
                levelController,
                levelFactory,
                itemFactory,
                screenFactory,
                playerFactory,
                enemyFactory,
                eventBus
                );

                gameController.Start();
            }
            finally
            {
                renderController.Dispose();
            }
        }
    }
}
