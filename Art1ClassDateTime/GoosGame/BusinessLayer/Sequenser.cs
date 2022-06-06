using System.Collections.Generic;

namespace GooseGame
{
    public class Sequenser
    {
        private readonly ILogger _logger;

        public Sequenser(Board board)
        {
            Board = board;
            _logger = new ConsoleLogger();
        }

        public Board Board { get; set; }
        public int TurnCount { get; private set; } = 0;
        public int SpaceForward { get; set; } = 0;
        public bool BackForward { get; set; } = false;
        public IPiece CurrentPiece { get; set; }
        private Queue<IPiece> TurnContainer { get; set; }

        public bool Start()
        {
            TurnContainer = new Queue<IPiece>();
            if (!PrepareTurnContainer())
            {
                _logger.Log("There are no players in the game");
                return false;
            }
            _logger.Log("Turn 0");
            return true;
        }

        public void Stop()
        {
            TurnCount = 0;
            if (TurnContainer!=null)
            {
                TurnContainer.Clear();
            }
        }

        public bool Roll()
        {
            bool stopgame = false;
            DiceRoller dice = this.Board.DiceRoller;
            dice?.Roll();
            SpaceForward = dice.DicesScore;
            if (TurnContainer.Count != 0)
            {
                CurrentPiece = TurnContainer.Dequeue();

                if (TurnCount == 0 && CurrentPiece.PieceCurrentSpace.Index == 1)
                {
                    if ((dice.Scoores[0] == 5 && dice.Scoores[1] == 4) ||
                            (dice.Scoores[1] == 5 && dice.Scoores[0] == 4))
                    {
                        SpaceForward = 25;
                    }
                    else if ((dice.Scoores[0] == 6 && dice.Scoores[1] == 3) ||
                            (dice.Scoores[1] == 6 && dice.Scoores[0] == 3))
                    {
                        SpaceForward = 52;
                    }
                }

                stopgame = StartAction(CurrentPiece, MakeTurn(CurrentPiece));
            }
            else

            {
                TurnCount++;
                _logger.Log($"Turn {TurnCount}");

                foreach (var piece in Board.Pieces)
                {
                    if (piece.LeftRollsToMiss > 0) piece.LeftRollsToMiss--;
                }
                PrepareTurnContainer();
                stopgame=Roll();
            }
            return stopgame;
        }

        public bool StartAction(IPiece spiece, ISpace toSpace)
        {
            bool won = false;

            switch (toSpace.Action)
            {
                case Rules.ActionRules.None:
                    {
                        spiece.LocateTo(toSpace);
                        break;
                    }
                case Rules.ActionRules.GoToStart:
                    {
                        spiece.LocateTo(Board.Spaces[1]);
                        _logger.Log($"{spiece.PiecePlayer.Name} Go to start!");
                        break;
                    }
                case Rules.ActionRules.FlyWithGoos:
                    {
                        spiece.LocateTo(toSpace);
                        string reverse = BackForward ? "reverse" : "";
                        _logger.Log($"{spiece.PiecePlayer.Name} Fly with {reverse} goos!");
                        SpaceForward = BackForward ? SpaceForward * (-1) : SpaceForward; //reverse goos
                        won = StartAction(spiece, MakeTurn(spiece));
                        break;
                    }
                case Rules.ActionRules.GoTo12:
                    {
                        spiece.LocateTo(Board.Spaces[12]);
                        _logger.Log($"{spiece.PiecePlayer.Name} goes to 12!");
                        break;
                    }
                case Rules.ActionRules.GoTo39:
                    {
                        spiece.LocateTo(Board.Spaces[39]);
                        _logger.Log($"{spiece.PiecePlayer.Name} goes to 39!");
                        break;
                    }
                case Rules.ActionRules.SkipOneTurn:
                    {
                        spiece.LocateTo(toSpace);
                        spiece.LeftRollsToMiss = 2;
                        _logger.Log($"{spiece.PiecePlayer.Name} skip one turn!");
                        break;
                    }
                case Rules.ActionRules.SkipThreeTurns:
                    {
                        spiece.LocateTo(toSpace);
                        spiece.LeftRollsToMiss = 4;
                        _logger.Log($"{spiece.PiecePlayer.Name} skip three turns!");
                        break;
                    }
                case Rules.ActionRules.WaitUntilAnotherArrives:
                    {
                        spiece.LocateTo(toSpace);
                        _logger.Log($"{spiece.PiecePlayer.Name} skip turn until another player arrives! ");
                        spiece.TurnOffUntilAnother = true;
                        foreach (var spie in Board.Pieces)
                        {
                            if (spie.PieceCurrentSpace.Action == Rules.ActionRules.WaitUntilAnotherArrives
                                 && spiece.PiecePlayer.Name != spie.PiecePlayer.Name)
                            {
                                spie.TurnOffUntilAnother = false;
                                _logger.Log($"{spie.PiecePlayer.Name} can continue playing");
                            }
                        }
                        break;
                    }
                case Rules.ActionRules.WinnerStopGame:
                    {
                        spiece.LocateTo(toSpace);
                        _logger.Log($"Game Over {spiece.PiecePlayer.Name} won!");
                        won = true;
                        break;
                    }
            }
            return won;
        }

        public ISpace MakeTurn(IPiece current)
        {
            BackForward = false;
            int forwardIndex = current.PieceCurrentSpace.Index + SpaceForward;
            int maxIndex = this.Board.MaxIndex;
            if (forwardIndex >= maxIndex)
            {
                forwardIndex = maxIndex - (forwardIndex - maxIndex);
                BackForward = true;
            }
            ISpace space = this.Board.Spaces[forwardIndex];
            SpaceForward = Board.DiceRoller.DicesScore;
            _logger.Log($"Piece {current.PiecePlayer.Name} {current.PieceCurrentSpace.Index} with {SpaceForward} eyes ({this.Board.DiceRoller.Scoores[0].ToString()}+{this.Board.DiceRoller.Scoores[1].ToString()}) relocate to {space.Name} {space.Index} with {space.Action}");

            return space;
        }

        private bool PrepareTurnContainer()
        {
            bool success = false;
            foreach (var piece in Board.Pieces)
            {
                if (piece.LeftRollsToMiss == 0 && !piece.TurnOffUntilAnother)
                {
                    TurnContainer.Enqueue(piece);
                    success = true;
                }
            }
            return success;
        }
    }
}