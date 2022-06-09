﻿namespace GooseGame
{
    public class Player : IPlayer
    {
        public Player(string name, string pass)
        {
            Name = name;
            Pass = pass;
        }

        public Player(string name)
        {
            Name = name;
        }

        public bool IsPlayerActive { get; set; }
        public string Name { get; set; }
        public string Pass { get; set; }
        public int GameIndex { get; set; }

        public void Logon(IPiece piece)
        { }
    }
}