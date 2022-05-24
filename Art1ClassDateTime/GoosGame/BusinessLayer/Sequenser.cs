using System;
using System.Collections.Generic;

namespace GooseGame
{
    public class Sequenser
    {
        private readonly ConsoleLogger _logger;
        public Sequenser(Board board)
        {
            Board = board;
            _logger = this.Board.Logger;   
        }
        public Board Board { get; set; }
        public int TurnCount { get; private set; } = 0;
        public int SpaceForward { get; set; }= 0;
        public bool BackForward { get; set; } = false;
        private Queue<Piece> TurnContainer { get; set; }

        public bool Start() 
        {
           TurnContainer = new Queue<Piece>();
           if(!PrepareTurnContainer())
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
            TurnContainer.Clear();
        }
        public bool Roll() 
        {
            bool stopgame = false;
            Piece currentspiece = null;
            DiceRoller dice = this.Board.DiceRoller;
            dice?.Roll();
            SpaceForward = dice.DicesScore;
            if (TurnContainer.Count != 0)
            {
                currentspiece = TurnContainer.Dequeue();

                if (TurnCount == 0 && currentspiece.PieceCurrentSpace.Index == 1)
                {
                    if ((dice.Scoores[0] == 5 && dice.Scoores[1] == 4) ||
                            (dice.Scoores[1] == 5 && dice.Scoores[0] == 4))
                    {
                        SpaceForward = 26;
                    }
                    else if ((dice.Scoores[0] == 6 && dice.Scoores[1] == 3) ||
                            (dice.Scoores[1] == 6 && dice.Scoores[0] == 3))
                    {
                        SpaceForward = 53;
                    }
                }

                stopgame = StartAction(currentspiece, MakeTurn(currentspiece));

            }
            else
            
            {
                TurnCount++;
                _logger.Log($"Turn {TurnCount}");
                
                foreach(var piece in Board.Pieces)
                {
                    if (piece.LeftRollsToMiss > 0) piece.LeftRollsToMiss--;
                }
                PrepareTurnContainer();
            }
            return stopgame; 
        }

        public bool StartAction(Piece spiece, ISpace toSpace)
        {
            bool won = false;
            switch (toSpace.Action)
            {
                case Rules.None:
                {
                        spiece.LocateTo(toSpace); 
                        break;
                }
                case Rules.GoToStart:
                {
                        spiece.LocateTo(Board.Spaces[1]);
                        _logger.Log($"{spiece.PiecePlayer.Name} Go to start!");
                        break;
                }
                case Rules.FlyWithGoos:
                {
                        spiece.LocateTo(toSpace);
                        string reverse = BackForward ? "reverse" : "";
                        _logger.Log($"{spiece.PiecePlayer.Name} Fly with {reverse} goos!");
                        SpaceForward = BackForward ? (-1) * SpaceForward : SpaceForward;
                        won = StartAction(spiece, MakeTurn(spiece));
                        break;
                }
                case Rules.GoTo12:
                {
                        spiece.LocateTo(Board.Spaces[12]);
                        _logger.Log($"{spiece.PiecePlayer.Name} goes to 12!");
                        break;
                }
                case Rules.GoTo39:
                {
                        spiece.LocateTo(Board.Spaces[39]);
                        _logger.Log($"{spiece.PiecePlayer.Name} goes to 39!");
                        break;
                }
                case Rules.SkipOneTurn:
                {
                        spiece.LocateTo(toSpace);
                        spiece.LeftRollsToMiss = 2;
                        _logger.Log($"{spiece.PiecePlayer.Name} skip one turn!");
                        break;
                }
                case Rules.SkipThreeTurns:
                {
                        spiece.LocateTo(toSpace);
                        spiece.LeftRollsToMiss = 4;
                        _logger.Log($"{spiece.PiecePlayer.Name} skip three turns!");
                        break;
                }
                case Rules.WaitUntilAnotherArrives:
                {
                        spiece.LocateTo(toSpace);
                        _logger.Log($"{spiece.PiecePlayer.Name} skip turn until another player arrives! ");
                        spiece.TurnOffUntilAnother = true;
                        foreach (var spie in Board.Pieces)
                        {
                            if (spie.PieceCurrentSpace.Action == Rules.WaitUntilAnotherArrives
                                 && spiece.PiecePlayer.Name != spie.PiecePlayer.Name)
                            {
                                spie.TurnOffUntilAnother = false;
                                _logger.Log($"{spie.PiecePlayer.Name} can continue playing");
                            }

                        }
                        break;
                }
                case Rules.WinnerStopGame:
                {
                        _logger.Log($"Game Over {spiece.PiecePlayer.Name} won!");
                        won = true;
                        break;
                }
            }
            return won;

        }
        public ISpace MakeTurn(Piece current)
        {
            BackForward = false;
            int forwardIndex = current.PieceCurrentSpace.Index + SpaceForward;
            int maxIndex = this.Board.MaxIndex;
            if(forwardIndex >= maxIndex)
            { 
                forwardIndex = maxIndex - (forwardIndex - maxIndex);
                BackForward = true;
            }
            ISpace space = this.Board.Spaces[forwardIndex];
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