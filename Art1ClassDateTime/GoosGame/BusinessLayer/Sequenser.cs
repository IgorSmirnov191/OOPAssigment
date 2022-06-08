using System;
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

        public string TurnLog { get; set; }
        public Tuple<bool, string> Start()
        {
            TurnContainer = new Queue<IPiece>();
           
            if (!PrepareTurnContainer())
            {
                TurnLog = "There are no players in the game! ";
                _logger.Log(TurnLog);
                return Tuple.Create(false, TurnLog);
            }
            string ruleslog = "Turn 0: ";
            _logger.Log(ruleslog);
            return Tuple.Create(true,"Good luck! ");
        }

        public void Stop()
        {
            TurnCount = 0;
            if (TurnContainer!=null)
            {
                TurnContainer.Clear();
            }
        }

        public Tuple<bool,string> Roll()
        {
           
            bool stopgame = false;
            var stopgamemessage = Tuple.Create(stopgame, TurnLog);
           
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

                stopgamemessage = StartAction(CurrentPiece, MakeTurn(CurrentPiece));
            }
            else

            {
                TurnCount++;
                string ruleslog = $"Turn {TurnCount}: ";
                _logger.Log(ruleslog);

                foreach (var piece in Board.Pieces)
                {
                    if (piece.LeftRollsToMiss > 0) piece.LeftRollsToMiss--;
                }
                PrepareTurnContainer();
                stopgamemessage = Roll();
            }
            return stopgamemessage;
        }

        public Tuple<bool, string> StartAction(IPiece spiece, ISpace toSpace)
        {
            bool won = false;
            var wonmessage = Tuple.Create(won, TurnLog);

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
                        string ruleslog = $"{spiece.PiecePlayer.Name} Go to start! ";
                        TurnLog += ruleslog;
                        _logger.Log(ruleslog);
                        break;
                    }
                case Rules.ActionRules.FlyWithGoos:
                    {
                        spiece.LocateTo(toSpace);
                        string reverse = BackForward ? "reverse" : "";
                        string ruleslog = $"{spiece.PiecePlayer.Name} Fly with {reverse} goos! ";
                        TurnLog += ruleslog;
                        _logger.Log(ruleslog);
                        SpaceForward = BackForward ? SpaceForward * (-1) : SpaceForward; //reverse goos
                        wonmessage = StartAction(spiece, MakeTurn(spiece));
                        break;
                    
                    }
                case Rules.ActionRules.GoTo12:
                    {
                        spiece.LocateTo(Board.Spaces[12]);
                        string ruleslog = $"{spiece.PiecePlayer.Name} goes to 12! ";
                        TurnLog += ruleslog;
                        _logger.Log(ruleslog);
                        break;
                    }
                case Rules.ActionRules.GoTo39:
                    {
                        spiece.LocateTo(Board.Spaces[39]);
                        string ruleslog = $"{spiece.PiecePlayer.Name} goes to 39! ";
                        TurnLog += ruleslog;
                        _logger.Log(ruleslog);
                        break;
                    }
                case Rules.ActionRules.SkipOneTurn:
                    {
                        spiece.LocateTo(toSpace);
                        spiece.LeftRollsToMiss = 2;
                        string ruleslog = $"{spiece.PiecePlayer.Name} skip one turn! ";
                        TurnLog += ruleslog;
                        _logger.Log(ruleslog);
                        break;
                    }
                case Rules.ActionRules.SkipThreeTurns:
                    {
                        spiece.LocateTo(toSpace);
                        spiece.LeftRollsToMiss = 4;
                        string ruleslog = $"{spiece.PiecePlayer.Name} skip three turns! ";
                        TurnLog += ruleslog;
                        _logger.Log(ruleslog);
                        break;
                    }
                case Rules.ActionRules.WaitUntilAnotherArrives:
                    {
                        spiece.LocateTo(toSpace);
                        string ruleslog = $"{spiece.PiecePlayer.Name} skip turn until another player arrives! ";
                        TurnLog += ruleslog;
                        _logger.Log(ruleslog);
                        spiece.TurnOffUntilAnother = true;
                        foreach (var spie in Board.Pieces)
                        {
                            if (spie.PieceCurrentSpace.Action == Rules.ActionRules.WaitUntilAnotherArrives
                                 && spiece.PiecePlayer.Name != spie.PiecePlayer.Name)
                            {
                                spie.TurnOffUntilAnother = false;
                                string rulesloglocal = $"{spie.PiecePlayer.Name} can continue playing. ";
                                TurnLog += rulesloglocal;
                                _logger.Log(rulesloglocal);
                            }
                        }
                        break;
                    }
                case Rules.ActionRules.WinnerStopGame:
                    {
                        spiece.LocateTo(toSpace);
                        string ruleslog = $"Game Over {spiece.PiecePlayer.Name} won! ";
                        TurnLog += ruleslog;
                        _logger.Log(ruleslog);
                        wonmessage = Tuple.Create(true, TurnLog);
                        break;
                    }
            }
            return wonmessage;
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
            string _spaceName = space.Type != SpaceTypes.StaticSpace? $"{space.Name} {space.Index}":$"{space.Name}";
            string _action = space.Action == Rules.ActionRules.None ? "": $"with {space.Action}";
            string ruleslog = $"{current.PiecePlayer.Name} from {current.PieceCurrentSpace.Index} with {SpaceForward} eyes ({this.Board.DiceRoller.Scoores[0].ToString()}+{this.Board.DiceRoller.Scoores[1].ToString()}) relocate to {_spaceName} {_action} . ";
            TurnLog += ruleslog;
            _logger.Log(ruleslog);

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