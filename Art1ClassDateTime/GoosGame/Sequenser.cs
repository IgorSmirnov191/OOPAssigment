using System;
using System.Collections.Generic;

namespace GooseGame
{
    public class Sequenser
    {
        public Sequenser(Board board)
        { 
            Board = board;
        }
        public Board Board { get; set; }
        public int TurnCount { get; private set; } = 0;

        private Queue<Piece> TurnContainer { get; set; }

        public void Start() 
        {
           TurnContainer = new Queue<Piece>();
           PrepareTurnContainer();
        }
        public void Stop()
        {
            TurnCount = 0;
            TurnContainer.Clear();
        }
        public bool Roll() 
        {
            DiceRoller dice = this.Board.DiceRoller;
            dice?.Roll();
            int spaceForward = dice.DicesScore;

            Piece spiece = TurnContainer.Dequeue();

            if (TurnCount == 0 && spiece.PieceCurrentSpace.Index == 1)
            {
                if (dice.Scoores[0] == 5 && dice.Scoores[1] == 4)
                {
                    spaceForward = 26;
                }
                else if (dice.Scoores[0] == 6 && dice.Scoores[1] == 3)
                {
                    spaceForward = 53;
                }

            }
            
            ISpace space = MakeTurn(spiece, spaceForward);
            if (space.Action == Rules.None)
            {
                spiece.LocateTo(space);

            }
            else if (space.Action == Rules.GoToStart)
            {
                spiece.LocateTo(Board.Spaces[1]);
                Console.WriteLine($"{spiece.PiecePlayer.Name} Go to start!");

            }
            else if (space.Action == Rules.FlyWithGoos)
            {
               
                spiece.LocateTo(space);
                Console.WriteLine($"{spiece.PiecePlayer.Name} Fly with goos!");
                space = MakeTurn(spiece, spaceForward);
                if (space.Action == Rules.WinnerStopGame)
                {
                    Console.WriteLine($"Game Over {spiece.PiecePlayer.Name} won!");
                    return true;
                }
                spiece.LocateTo(space);
               

            }
            else if (space.Action == Rules.GoTo12)
            {
                spiece.LocateTo(Board.Spaces[12]);
                Console.WriteLine($"{spiece.PiecePlayer.Name} goes to 12!");
            }
            else if (space.Action == Rules.GoTo39)
            {
                spiece.LocateTo(Board.Spaces[39]);
                Console.WriteLine($" {spiece.PiecePlayer.Name} goes to 39!");
            }
            else if (space.Action == Rules.SkipOneTurn)
            {
                spiece.LocateTo(space);
                spiece.LeftRollsToMiss = 2;
                Console.WriteLine($"{spiece.PiecePlayer.Name} skip one turn!");
            }
            
            else if (space.Action == Rules.SkipThreeTurns)
            {
                spiece.LocateTo(space);
                spiece.LeftRollsToMiss = 4;
                Console.WriteLine($"{spiece.PiecePlayer.Name} skip three turns!");
            }
            else if (space.Action == Rules.WaitUntilAnotherArrives)
            {
                spiece.LocateTo(space);
                Console.WriteLine($"{spiece.PiecePlayer.Name} skip turn until another player arrives! ");
                spiece.TurnOffUntilAnother = true;
                foreach (var spie in Board.Pieces)
                {
                    if (spie.PieceCurrentSpace.Action == Rules.WaitUntilAnotherArrives
                         && spiece.PiecePlayer.Name != spie.PiecePlayer.Name)
                    {
                        spie.TurnOffUntilAnother = false;
                        Console.WriteLine($"{spie.PiecePlayer.Name} can continue playing");
                    }

                }

            }
            else if (space.Action == Rules.WinnerStopGame)
            {
                Console.WriteLine($"Game Over {spiece.PiecePlayer.Name} won!");
                return true;
            }
            if(TurnContainer.Count == 0)
            {
                TurnCount++;
                Console.WriteLine($"Turn {TurnCount}");
                
                foreach(var piece in Board.Pieces)
                {
                    if (piece.LeftRollsToMiss > 0) piece.LeftRollsToMiss--;
                }
                PrepareTurnContainer();
            }
            return false; 
        }
        private ISpace MakeTurn(Piece current, int spaceForward)
        {
            int eyes = spaceForward;
            int forwardIndex = current.PieceCurrentSpace.Index + spaceForward;
            int maxIndex = this.Board.MaxIndex;
            if(forwardIndex >= maxIndex)
            { 
                forwardIndex = maxIndex - (forwardIndex - maxIndex); 
            }
            ISpace space = this.Board.Spaces[forwardIndex];
            Console.WriteLine($"Piece {current.PiecePlayer.Name} {current.PieceCurrentSpace.Index} with {eyes} eyes ({this.Board.DiceRoller.Scoores[0].ToString()}+{this.Board.DiceRoller.Scoores[1].ToString()}) relocate to {space.Name} {space.Index} with {space.Action}");
           
            return space;
        }
        private void PrepareTurnContainer() 
        {
            foreach (var piece in Board.Pieces)
            {
                if (piece.LeftRollsToMiss == 0 && !piece.TurnOffUntilAnother)
                {
                    TurnContainer.Enqueue(piece);
                }
            }
        }


    }
}