using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using GooseGame;

namespace GooseGame.Tests
{
    public class GooseGameTests
    {
        [Fact]
        public void MakeTurn_NextSpaceShouldCalculate()
        {
            // Arrange
            ISpace expected = new StaticSpace(5, null);

            // Act
            Board board = new Board(new SpacePack(63));
            Piece piece = new Piece(new Player("P1", "Password"));
            Game game = new Game("GooseBoard", board);
            game.ActiveBoard.Pieces.Add(piece);
            board.Sequenser.Board.DiceRoller.Scoores.Add(1);
            board.Sequenser.Board.DiceRoller.Scoores.Add(3);
            board.Sequenser.SpaceForward = 4;
            ISpace actual = board.Sequenser.MakeTurn(piece);

            // Assert
            Assert.Equal(expected.Index, actual.Index);

        }
    }
}
