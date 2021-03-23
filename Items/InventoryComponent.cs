using GunCleric.Atoms;
using GunCleric.Events;
using GunCleric.Game;
using GunCleric.Geometry;
using GunCleric.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Items
{
    public class InventoryComponent : IAtomComponent
    {
        public Atom Atom { get; set; }

        private IList<Atom> _inventory = new List<Atom>();
        private readonly LevelController _levelController;
        private readonly EventBus _eventBus;

        public Type GetComponentInterface() => typeof(InventoryComponent);

        public InventoryComponent(Atom atom, LevelController levelController, EventBus eventBus)
        {
            Atom = atom;
            _levelController = levelController;
            _eventBus = eventBus;
        }

        public void PickUp(GameState gameState)
        {
            var item = _levelController.GetAtoms(
                new GamePosition(Atom.Position.X, Atom.Position.Y, Atom.Position.Level, Layer.OnFloor), 
                gameState
            ).FirstOrDefault();

            if (item != null)
            {
                _levelController.RemoveLevelElement(item, gameState);
                _inventory.Add(item);
                _eventBus.RegisterEvent("PICKUP", new { doer = Atom, doee = item });
            }
        }
    }
}
