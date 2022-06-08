using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GooseGame;

namespace GooseGameConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game("GooseBoard", new Board(new SpacePack(Rules.MaxSpaceIndex)));
            game.ActiveBoard.Pieces.Add(new Piece(new Player("P1", "Password")));
            game.ActiveBoard.Pieces.Add(new Piece(new Player("P2", "Password")));
            game.ActiveBoard.Pieces.Add(new Piece(new Player("P3", "Password")));
            game.ActiveBoard.Pieces.Add(new Piece(new Player("P4", "Password")));
            var boardToStart = game.ActiveBoard.Start();
            if (!boardToStart.Item1)
            {
                return;
            }

            bool won = false;
            while (!won)
            {
                var wongame = game.ActiveBoard.Roll();
                won = wongame.Item1;
            }

        }
    }
}
