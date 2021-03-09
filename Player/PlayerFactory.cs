using GunCleric.Agents;
using GunCleric.Atoms;
using GunCleric.Damaging;
using GunCleric.Events;
using GunCleric.Geometry;
using GunCleric.Items;
using GunCleric.Levels;
using System;

namespace GunCleric.Player
{
    public class PlayerFactory
    {
        private readonly LevelController _levelController;
        private readonly EventBus _eventBus;
        private readonly Random _random;

        public PlayerFactory(LevelController levelController, EventBus eventBus, Random random)
        {
            _levelController = levelController;
            _eventBus = eventBus;
            _random = random;
        }

        public Atom CreatePlayer(string name, GamePosition position)
        {
            var player = new Atom("Player", '@', position);
            var damagerComponent = new DamagerComponent(player, _eventBus);
            player.AddComponent(damagerComponent);
            var interactionComponent = new PlayerInteractionComponent(player, _levelController, damagerComponent, _random);
            player.AddComponent(interactionComponent);
            var inputActionController = new PlayerInputActionController(player, interactionComponent);
            player.AddComponent(inputActionController);
            var uniqueComponent = new UniqueAtomComponent(player, name);
            player.AddComponent(uniqueComponent);
            var inventoryComponent = new InventoryComponent(player, _levelController);
            player.AddComponent(inventoryComponent);
            var agentComponent = new AgentComponent(player);
            player.AddComponent(agentComponent);
            return player;
        }
    }
}