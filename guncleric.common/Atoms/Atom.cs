using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GunCleric.Game;
using GunCleric.Geometry;
using GunCleric.Player;
using GunCleric.Rendering;

namespace GunCleric.Atoms
{
    [DataContract]
    [KnownType(typeof(UniqueAtomComponent))]
    [KnownType(typeof(PlayerInputActionController))]
    public class Atom
    {
        [DataMember]
        public IDictionary<Type, IAtomComponent> Components = new Dictionary<Type, IAtomComponent>();
        [DataMember]
        public string Type;
        [DataMember]
        public ColouredChar Tile;
        [DataMember]
        public GamePosition Position;

        public Atom(string type, ColouredChar tile, GamePosition position)
        {
            Type = type;
            Tile = tile;
            Position = position;
        }

        public void AddComponent(IAtomComponent component)
        {
            var type = component.GetComponentInterface();
            if (!Components.ContainsKey(type))
            {
                Components[type] = component;
            }
            else
            {
                throw new Exception($"Component of type {type} already exists for this Atom");
            }
        }

        public bool HasComponent<T>() where T : IAtomComponent
        {
            return Components.ContainsKey(typeof(T));
        }

        public T GetComponent<T>() where T : IAtomComponent
        {
            return (T)Components[typeof(T)];
        }

        public bool TryGetComponent<T>(out T component) where T : IAtomComponent
        {
            component = default;

            if (HasComponent<T>())
            {
                component = GetComponent<T>();
                return true;
            }

            return false;
        }

        public void MoveAtom(GamePosition newPosition, GameState state)
        {
            var oldPosition = Position;
            try
            {
                var level = state.Levels[oldPosition.Level];

                var newLevel = state.Levels[newPosition.Level];

                if (level != newLevel)
                {
                    throw new NotImplementedException();
                }

                Position = newPosition;

                level.UpdateLevelElement(oldPosition, this);
            }
            catch (Exception)
            {
                Position = oldPosition;
            }
        }

        public override string ToString()
        {
            if (TryGetComponent<UniqueAtomComponent>(out var unique))
            {
                return unique.Name;
            }
            else return Type;
        }
    }
}