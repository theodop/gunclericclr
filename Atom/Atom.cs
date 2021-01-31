using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GunCleric.Geometry;
using GunCleric.Player;

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
        public char Tile;
        [DataMember]
        public GamePosition Position;

        public Atom(string type, char tile, GamePosition position)
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
    }
}