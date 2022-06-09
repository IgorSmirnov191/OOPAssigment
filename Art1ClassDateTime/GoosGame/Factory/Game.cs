using System.Collections.Generic;

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

        public Game(Board activeBoard)
        {
            Boards.Add(activeBoard);
            ActiveBoard = activeBoard;
        }

        public string Name { get; set; } = "GooseGame";
        public List<Board> Boards { get; set; } = new List<Board>();
        public List<ISpace> Spaces { get; set; } = new List<ISpace>();

        public Board ActiveBoard { get; set; } = null;

        public void Exit()
        { }

        public bool Suspend()
        { return true; }

        public bool Resume()
        { return true; }
    }
}