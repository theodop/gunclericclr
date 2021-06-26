using GunCleric.Agents;
using GunCleric.Atoms;
using GunCleric.Damaging;
using GunCleric.Events;
using GunCleric.Geometry;
using GunCleric.Items;
using GunCleric.Levels;
using GunCleric.Random;
using GunCleric.Scheduler;
using System;

namespace GunCleric.Player
{
    public class PlayerFactory
    {
        private readonly LevelController _levelController;
        private readonly EventBus _eventBus;
        private readonly Randomiser _random;
        private readonly ScheduleController _scheduleController;

        public PlayerFactory(LevelController levelController, EventBus eventBus, Randomiser random,
            ScheduleController scheduleController)
        {
            _levelController = levelController;
            _eventBus = eventBus;
            _random = random;
            _scheduleController = scheduleController;
        }

        public Atom CreatePlayer(string name, GamePosition position)
        {
            var player = new Atom("Player", '@', position);
            var damagerComponent = new DamagerComponent(player, _eventBus);
            player.AddComponent(damagerComponent);
            var interactionComponent = new PlayerInteractionComponent(player, _levelController, damagerComponent, _random);
            player.AddComponent(interactionComponent);
            var inputActionController = new PlayerInputActionController(player, interactionComponent, _scheduleController);
            player.AddComponent(inputActionController);
            var uniqueComponent = new UniqueAtomComponent(player, name);
            player.AddComponent(uniqueComponent);
            var inventoryComponent = new InventoryComponent(player, _levelController, _eventBus);
            player.AddComponent(inventoryComponent);
            var agentComponent = new AgentComponent(player);
            player.AddComponent(agentComponent);
            return player;
        }
    }
}