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

        [Fact]
        public void MakeTurn_NextSpaceToMaxIdexAndBackShouldCalculate()
        {
            // Arrange
            ISpace expected = new StaticSpace(57, null);

            // Act
            int MaxIndex = 63;
            Board board = new Board(new SpacePack(MaxIndex));
            Piece piece = new Piece(new Player("P1", "Password"));
            Game game = new Game("GooseBoard", board);
            game.ActiveBoard.Pieces.Add(piece);
            piece.PieceCurrentSpace.Index = 57;
            board.Sequenser.Board.DiceRoller.Scoores.Add(5);
            board.Sequenser.Board.DiceRoller.Scoores.Add(5);
            board.Sequenser.SpaceForward = 10;
            ISpace actual = board.Sequenser.MakeTurn(piece);
            if (actual.Type == SpaceTypes.GooseSpace)
            {
                piece.PieceCurrentSpace.Index = actual.Index;
                actual = board.Sequenser.MakeTurn(piece);
            }
                
               

            // Assert
            Assert.Equal(expected.Index, actual.Index);

        }
    }
}
