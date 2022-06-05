using System.Collections.Generic;

namespace GooseGame
{
    public class Board
    {
        public Board(SpacePack pak)
        {
            Spaces = pak.Spaces;
            MaxIndex = pak.MaxIndexOfBoard;
            Sequenser = new Sequenser(this);
            Logger = new ConsoleLogger();
            DiceRoller = new DiceRoller(Rules.DoubleDicer);
        }

        public int MaxIndex { get; set; }
        public IList<IPiece> Pieces { get; set; } = new List<IPiece>();
        public IList<ISpace> Spaces { get; set; }
        public Sequenser Sequenser { get; set; }
        public ILogger Logger { get; set; }

        public DiceRoller DiceRoller { get; set; }

        public string Layout { get; set; }

        public bool Start()
        {
            foreach (IPiece piece in Pieces)
            {
                piece.LocateTo(new StartSpace(1));
            }
            return Sequenser.Start();
        }

        public void Stop()
        {
            foreach(IPiece piece in Pieces)
            {
                piece.LocateTo(new StaticSpace(0));
            }
            Sequenser.Stop();
        }
        public void Commit()
        { }

        public bool Roll()
        {
            return Sequenser.Roll();
        }
    }
}