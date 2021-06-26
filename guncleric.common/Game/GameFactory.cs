using GunCleric.Assets;
using GunCleric.Enemies;
using GunCleric.Events;
using GunCleric.Input;
using GunCleric.Items;
using GunCleric.Levels;
using GunCleric.Player;
using GunCleric.Random;
using GunCleric.Rendering;
using GunCleric.Saving;
using GunCleric.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Game
{
    public class GameFactory
    {
        public GameController GetGameController(IOutputter outputter)
        {
            var randomiser = new Randomiser(new System.Random());
            var scheduleController = new ScheduleController();
            var renderController = new RenderController(outputter);
            var inputController = new InputController();
            var saveController = new SaveController();
            var levelController = new LevelController();
            var levelFactory = new LevelFactory(randomiser);
            var itemFactory = new ItemFactory();
            var stringFormatter = new StringFormatterSmartFormat();
            var assetBank = new AssetBank(stringFormatter);
            var eventBus = new EventBus();
            var eventKeeper = new EventKeeper(eventBus, assetBank);
            var screenFactory = new ScreenFactory(eventKeeper);
            var playerFactory = new PlayerFactory(levelController, eventBus, randomiser, scheduleController);
            var enemyFactory = new EnemyFactory(eventBus, randomiser, scheduleController);

            return new GameController(
                renderController,
                inputController,
                saveController,
                levelController,
                levelFactory,
                itemFactory,
                screenFactory,
                playerFactory,
                enemyFactory,
                eventBus,
                scheduleController
            );
        }
    }
}
