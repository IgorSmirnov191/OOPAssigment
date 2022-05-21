using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game("GooseBoard",new Board(new SpacePack(63)));
            game.ActiveBoard.Pieces.Add(new Piece(new Player("P1", "Password")));
            game.ActiveBoard.Pieces.Add(new Piece(new Player("P2", "Password")));
            game.ActiveBoard.Pieces.Add(new Piece(new Player("P3", "Password")));
            game.ActiveBoard.Pieces.Add(new Piece(new Player("P4", "Password")));
            if (!game.ActiveBoard.Start())
            {
                return;
            }
                     
            bool won = false;
            while (!won) 
            {
                won = game.ActiveBoard.Roll();
            }
            

        }
    }
}
