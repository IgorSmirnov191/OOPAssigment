using System.Collections.Generic;

namespace GooseGame
{
    public class Board
    {
        public const int DoubleDicer = 2;

        public Board(SpacePack pak)
        {
            Spaces = pak.Spaces;
            MaxIndex = pak.MaxIndexOfBoard;
            Sequenser = new Sequenser(this);
            Logger = new ConsoleLogger();
            DiceRoller = new DiceRoller(DoubleDicer);
        }

        public int MaxIndex { get; set; }
        public IList<Piece> Pieces { get; set; } = new List<Piece>();
        public IList<ISpace> Spaces { get; set; }
        public Sequenser Sequenser { get; set; }
        public ILogger Logger { get; set; }

        public DiceRoller DiceRoller { get; set; }

        public string Layout { get; set; }

        public bool Start()
        {
            return Sequenser.Start();
        }

        public void Commit()
        { }

        public bool Roll()
        {
            return Sequenser.Roll();
        }
    }
}