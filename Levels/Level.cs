using GunCleric.Atoms;
using GunCleric.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Levels
{
    public class Level
    {
        abstract class LevelSlot
        {
            public abstract IEnumerable<Atom> GetAtomsInSlot();
        }

        class LevelSlotSingle : LevelSlot
        {
            Atom _atom;
            public LevelSlotSingle(Atom atom)
            {
                _atom = atom;
            }

            public override IEnumerable<Atom> GetAtomsInSlot()
            {
                yield return _atom;
            }
        }

        class LevelSlotMulti : LevelSlot
        {
            LinkedList<Atom> _atoms;
            public LevelSlotMulti(IEnumerable<Atom> atoms)
            {
                _atoms = new LinkedList<Atom>(atoms);
            }
            public override IEnumerable<Atom> GetAtomsInSlot()
            {
                return _atoms;
            }

            public void Push(Atom atom)
            {
                _atoms.AddLast(atom);
            }

            internal void Remove(Atom atom)
            {
                _atoms.Remove(atom);
            }
        }


        public enum AddStyle
        {
            Overwrite,
            Stack,
            Error
        }

        public int LevelNumber { get; }

        private IDictionary<(int, int, Layer), LevelSlot> _levelElements =
            new Dictionary<(int, int, Layer), LevelSlot>();

        public Level(int levelNumber)
        {
            LevelNumber = levelNumber;
        }

        internal void AddLevelElement(Atom atom, AddStyle addStyle = AddStyle.Error)
        {
            var key = (atom.Position.X, atom.Position.Y, atom.Position.Layer);
            switch (addStyle)
            {
                case AddStyle.Overwrite:
                    _levelElements[key] = new LevelSlotSingle(atom);
                    break;
                case AddStyle.Stack:
                    if (_levelElements.ContainsKey(key))
                    {
                        if (_levelElements[key] is LevelSlotSingle slot)
                        {
                            _levelElements[key] = new LevelSlotMulti(slot.GetAtomsInSlot());
                        }
                        else if (_levelElements[key] is LevelSlotMulti slotMulti)
                        {
                            slotMulti.Push(atom);
                        }
                    }
                    else
                    {
                        _levelElements[key] = new LevelSlotSingle(atom);
                    }
                    break;
                case AddStyle.Error:
                    if (_levelElements.ContainsKey(key))
                    {
                        throw new Exception($"Already something in this position ({key.X}, {key.Y}, {key.Layer})");
                    }
                    _levelElements[key] = new LevelSlotSingle(atom);
                    break;
            }
        }

        internal void UpdateLevelElement(GamePosition oldPosition, Atom atom, AddStyle addStyle = AddStyle.Error)
        {
            AddLevelElement(atom);

            RemoveLevelElement(oldPosition, atom);
        }

        internal void RemoveLevelElement(GamePosition position, Atom atom)
        {
            var key = (position.X, position.Y, position.Layer);

            // sanity check
            if (!DoesSlotContain(atom))
            {
                throw new Exception("Atom is not where it should be");
            }

            if (_levelElements[key] is LevelSlotSingle)
            {
                _levelElements.Remove(key);
            }
            else if (_levelElements[key] is LevelSlotMulti slotMulti)
            {
                if (slotMulti.GetAtomsInSlot().Count() > 2)
                {
                    slotMulti.Remove(atom);
                }
                else
                {
                    _levelElements[key] = new LevelSlotSingle(slotMulti.GetAtomsInSlot().Single());
                }
            }
        }

        internal bool DoesSlotContain(Atom atom)
        {
            LevelSlot slot;
            if (_levelElements.TryGetValue((atom.Position.X, atom.Position.Y, atom.Position.Layer), out slot))
            {
                return slot.GetAtomsInSlot().Contains(atom);
            }
            else return false;
        }

        public IEnumerable<Atom> GetAtoms(int x, int y, Layer layer)
        {
            if (_levelElements.TryGetValue((x, y, layer), out var slot))
            {
                return slot.GetAtomsInSlot();
            }
            return new Atom[] { };
        }

        internal IEnumerable<Atom> GetAtoms(int x, int y)
        {
            return GetAtoms(x, y, Layer.Floor)
                .Concat(GetAtoms(x, y, Layer.OnFloor))
                .Concat(GetAtoms(x, y, Layer.Blocking));
        }
    }
}
