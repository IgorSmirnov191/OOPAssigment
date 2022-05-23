using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GooseGame;
using Xunit;

namespace GooseGame.Tests
{
     public class SequenserTests
    {
        [Fact]
        public void MakeTurn_NextSpaceShouldCalculate()
        {
            // Arrange
            ISpace expected = new StaticSpace(5,null);

            // Act
            Board board = new Board(new SpacePack(63));
            Piece piece = new Piece(new Player("P1", "Password"));
            Game game = new Game("GooseBoard", board);
            game.ActiveBoard.Pieces.Add(piece);
            board.Sequenser.SpaceForward = 5;
            ISpace actual = board.Sequenser.MakeTurn(piece);

            // Assert
            Assert.Equal(expected.Index, actual.Index);

        }
    }
}
