using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using GunCleric.Atoms;
using GunCleric.Rendering;
using GunCleric.Levels;

namespace GunCleric.Game
{
    [DataContract]
    public class GameState
    {
        [DataMember]
        public string PlayerName = "Bungus";
        [DataMember]
        public int Hp = 100;
        [DataMember]
        public int Xp = 0;
        [DataMember]
        public string Armour = "Cool coat";
        [DataMember]
        public string Weapon = "Sick pistol";

        [DataMember]
        public Screen CurrentScreen;

        [DataMember]
        public Atom Player;

        [DataMember]
        public Rectangle WindowSize = new Rectangle(0, 0, 80, 25);

        public IDictionary<int, Level> Levels = new Dictionary<int, Level>();

        public Level CurrentLevel;

        public char[,] LastImage;
    }
}