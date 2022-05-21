using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame
{
    public class Board
    {
        public Board(SpacePack pak)
        {
            Spaces = pak.Spaces;
            MaxIndex = pak.MaxIndexOfBoard;
            Sequenser = new Sequenser(this);

        }
        public int MaxIndex { get; set; }
        public List<Piece> Pieces { get; set; } = new List<Piece>();
        public List<ISpace> Spaces { get; set; }
        public Sequenser Sequenser { get; set; }

        public DiceRoller DiceRoller { get; set; } = new DiceRoller(2);

        public string Layout { get; set; }

        public bool Start()
        {
            return Sequenser.Start();
        }

        public void Commit() { }

        public bool Roll() { return Sequenser.Roll(); }

       
    }
}
