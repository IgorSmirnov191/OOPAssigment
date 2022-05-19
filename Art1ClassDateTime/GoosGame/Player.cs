using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame
{
    public class Player : IPlayer
    {
        public Player(string name, string pass) 
        {
            Name = name;
            Pass = pass;
        }
        public bool IsPlayerActive {get; set;}
        public string Name { get; set; }
        public string Pass { get; set; }

        public void Logon(IPiece piece) { }
    }
}
