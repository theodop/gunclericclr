using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using GunCleric.Atoms;
using GunCleric.Rendering;
using GunCleric.Levels;
using GunCleric.Scheduler;

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
        public Size WindowSize = new Size(80, 24);

        public IDictionary<int, Level> Levels = new Dictionary<int, Level>();

        public Level CurrentLevel;

        public RenderedImage LastImage;

        public Schedule Schedule = new Schedule();

        public DateTime CurrentTime = new DateTime(2016, 10, 8, 7, 22, 0);
    }
}