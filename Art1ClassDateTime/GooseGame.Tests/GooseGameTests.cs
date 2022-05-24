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
            ISpace expected = new StaticSpace(49, null);

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
                board.Sequenser.SpaceForward = board.Sequenser.BackForward ? (-1) * board.Sequenser.SpaceForward : board.Sequenser.SpaceForward;
                actual = board.Sequenser.MakeTurn(piece);
            }
  
            // Assert
            Assert.Equal(expected.Index, actual.Index);

        }
        [Fact]
        public void StartAction_WonStopGameShouldCalculate()
        {
            // Arrange
            bool expected = true;

            // Act
            int MaxIndex = 63;
            Board board = new Board(new SpacePack(MaxIndex));
            Piece piece = new Piece(new Player("P1", "Password"));
            Game game = new Game("GooseBoard", board);
            game.ActiveBoard.Pieces.Add(piece);
            piece.PieceCurrentSpace.Index = 55;
            board.Sequenser.Board.DiceRoller.Scoores.Add(1);
            board.Sequenser.Board.DiceRoller.Scoores.Add(3);
            board.Sequenser.SpaceForward = 4;

            bool actual = board.Sequenser.StartAction(piece, board.Sequenser.MakeTurn(piece));

            // Assert
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void StartAction_BridgeShouldCalculate()
        {
            // Arrange
            ISpace expected = new StaticSpace(12,null);
            // Act
            int MaxIndex = 63;
            Board board = new Board(new SpacePack(MaxIndex));
            Piece piece = new Piece(new Player("P1", "Password"));
            Game game = new Game("GooseBoard", board);
            game.ActiveBoard.Pieces.Add(piece);
            piece.PieceCurrentSpace.Index = 1;
            board.Sequenser.Board.DiceRoller.Scoores.Add(2);
            board.Sequenser.Board.DiceRoller.Scoores.Add(3);
            board.Sequenser.SpaceForward = 5;

            board.Sequenser.StartAction(piece, board.Sequenser.MakeTurn(piece));
            ISpace actual = piece.PieceCurrentSpace;
            // Assert
            Assert.Equal(expected.Index, actual.Index);

        }

        [Fact]
        public void StartAction_InnShouldCalculate()
        {
            // Arrange
            ISpace expected = new InnSpace(null);
            bool turnOffexpected = true;

            // Act
            int MaxIndex = 63;
            Board board = new Board(new SpacePack(MaxIndex));
            Piece piece = new Piece(new Player("P1", "Password"));
            Game game = new Game("GooseBoard", board);
            game.ActiveBoard.Pieces.Add(piece);
            piece.PieceCurrentSpace.Index = 4;
            board.Sequenser.Board.DiceRoller.Scoores.Add(2);
            board.Sequenser.Board.DiceRoller.Scoores.Add(3);
            board.Sequenser.SpaceForward = 5;

            board.Sequenser.StartAction(piece, board.Sequenser.MakeTurn(piece));
            ISpace actual = piece.PieceCurrentSpace;

            // Asserts

            Assert.Equal(expected.Index, actual.Index);
            Assert.Equal(turnOffexpected, piece.LeftRollsToMiss>1);

        }

        [Fact]
        public void StartAction_WellShouldCalculate()
        {
            // Arrange
            ISpace expected = new WellSpace(null);
            bool turnOffUntilexpected = true;

            // Act
            int MaxIndex = 63;
            Board board = new Board(new SpacePack(MaxIndex));
            Piece piece1 = new Piece(new Player("P1", "Password"));
            Piece piece2 = new Piece(new Player("P2", "Password"));
            Game game = new Game("GooseBoard", board);
            game.ActiveBoard.Pieces.Add(piece1);
            game.ActiveBoard.Pieces.Add(piece2);
            piece1.PieceCurrentSpace.Index = 19;
            board.Sequenser.Board.DiceRoller.Scoores.Add(2);
            board.Sequenser.Board.DiceRoller.Scoores.Add(2);
            board.Sequenser.SpaceForward = 4;
            board.Sequenser.StartAction(piece1, board.Sequenser.MakeTurn(piece1));
            ISpace actual = piece1.PieceCurrentSpace;
          
            // Asserts
            Assert.Equal(expected.Index, actual.Index);
            Assert.Equal(turnOffUntilexpected, piece1.TurnOffUntilAnother);

            piece2.PieceCurrentSpace.Index = 28;
            board.Sequenser.Board.DiceRoller.Scoores.Add(1);
            board.Sequenser.Board.DiceRoller.Scoores.Add(2);
            board.Sequenser.SpaceForward = 3;
            board.Sequenser.StartAction(piece2, board.Sequenser.MakeTurn(piece2));

            Assert.Equal(turnOffUntilexpected, piece2.TurnOffUntilAnother);
            
            turnOffUntilexpected = false;
            Assert.Equal(turnOffUntilexpected, piece1.TurnOffUntilAnother);

        }

        [Fact]
        public void StartAction_MazeShouldCalculate()
        {
            // Arrange
            ISpace expected = new StaticSpace(39, null);
            // Act
            int MaxIndex = 63;
            Board board = new Board(new SpacePack(MaxIndex));
            Piece piece = new Piece(new Player("P1", "Password"));
            Game game = new Game("GooseBoard", board);
            game.ActiveBoard.Pieces.Add(piece);
            piece.PieceCurrentSpace.Index = 39;
            board.Sequenser.Board.DiceRoller.Scoores.Add(1);
            board.Sequenser.Board.DiceRoller.Scoores.Add(2);
            board.Sequenser.SpaceForward = 3;

            board.Sequenser.StartAction(piece, board.Sequenser.MakeTurn(piece));
            ISpace actual = piece.PieceCurrentSpace;
            // Assert
            Assert.Equal(expected.Index, actual.Index);

        }

        [Fact]
        public void StartAction_DeathShouldCalculate()
        {
            // Arrange
            ISpace expected = new StaticSpace(1, null);
            // Act
            int MaxIndex = 63;
            Board board = new Board(new SpacePack(MaxIndex));
            Piece piece = new Piece(new Player("P1", "Password"));
            Game game = new Game("GooseBoard", board);
            game.ActiveBoard.Pieces.Add(piece);
            piece.PieceCurrentSpace.Index = 53;
            board.Sequenser.Board.DiceRoller.Scoores.Add(3);
            board.Sequenser.Board.DiceRoller.Scoores.Add(2);
            board.Sequenser.SpaceForward = 5;

            board.Sequenser.StartAction(piece, board.Sequenser.MakeTurn(piece));
            ISpace actual = piece.PieceCurrentSpace;
            // Assert
            Assert.Equal(expected.Index, actual.Index);

        }

        [Fact]
        public void StartAction_PrisonShouldCalculate()
        {
            // Arrange
            ISpace expected = new PrisonSpace(null);
            bool turnOffexpected = true;

            // Act
            int MaxIndex = 63;
            Board board = new Board(new SpacePack(MaxIndex));
            Piece piece = new Piece(new Player("P1", "Password"));
            Game game = new Game("GooseBoard", board);
            game.ActiveBoard.Pieces.Add(piece);
            piece.PieceCurrentSpace.Index = 48;
            board.Sequenser.Board.DiceRoller.Scoores.Add(1);
            board.Sequenser.Board.DiceRoller.Scoores.Add(1);
            board.Sequenser.SpaceForward = 2;

            board.Sequenser.StartAction(piece, board.Sequenser.MakeTurn(piece));
            ISpace actual = piece.PieceCurrentSpace;

            // Asserts

            Assert.Equal(expected.Index, actual.Index);
            Assert.Equal(turnOffexpected, piece.LeftRollsToMiss > 3);

        }
    }
}
