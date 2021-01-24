using System;
using System.Collections.Generic;
using GunCleric.Geometry;

namespace GunCleric.Atoms
{
    public class Atom
    {
        private IDictionary<Type, IAtomComponent> _components = new Dictionary<Type, IAtomComponent>();

        public string Type { get; }
        public char Tile { get; }
        public GamePosition Position { get; }

        public Atom(string type, char tile, GamePosition position)
        {
            Type = type;
            Tile = tile;
            Position = position;
        }

        public void AddComponent(IAtomComponent component)
        {
            var type = component.GetComponentInterface();
            if (!_components.ContainsKey(type))
            {
                _components[type] = component;
            }
            else
            {
                throw new Exception($"Component of type {type} already exists for this Atom");
            }
        }

        public bool HasComponent<T>() where T : IAtomComponent
        {
            return _components.ContainsKey(typeof(T));
        }

        public T GetComponent<T>() where T : IAtomComponent
        {
            return (T)_components[typeof(T)];
        }
    }
}