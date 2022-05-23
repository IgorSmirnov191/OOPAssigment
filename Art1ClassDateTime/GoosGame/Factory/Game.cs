using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame
{
    public class Game
    {
        public Game(string name, Board activeBoard)
        {
            Name = name;
            Boards.Add(activeBoard);
            ActiveBoard = activeBoard;
          
        }

        public string Name { get; set; }    
        public List<Board> Boards { get; set; } = new List<Board>();
        public List<ISpace> Spaces { get; set; } = new List<ISpace>();
      
        public Board ActiveBoard { get; set; }
        public void AddPayer(string name, string pas){ }
        public void PlayerLogon(string name, string pass) { }
        public void Exit() { }
        public bool Suspend() { return true; }
        public bool Resume() { return true; }
       
    }
}
