﻿using System;
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
        private int SpaceForward { get; set; }= 0;
        private Queue<Piece> TurnContainer { get; set; }

        public bool Start() 
        {
           TurnContainer = new Queue<Piece>();
           if(!PrepareTurnContainer())
            {
                Console.WriteLine("There are no players in the game");
                return false;
            }
           Console.WriteLine("Turn 0");
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
                Console.WriteLine($"Turn {TurnCount}");
                
                foreach(var piece in Board.Pieces)
                {
                    if (piece.LeftRollsToMiss > 0) piece.LeftRollsToMiss--;
                }
                PrepareTurnContainer();
            }
            return stopgame; 
        }

        private bool StartAction(Piece spiece, ISpace space)
        {
            bool won = false;
            switch (space.Action)
            {
                case Rules.None:
                {
                        spiece.LocateTo(space); 
                        break;
                }
                case Rules.GoToStart:
                {
                        spiece.LocateTo(Board.Spaces[1]);
                        Console.WriteLine($"{spiece.PiecePlayer.Name} Go to start!");
                        break;
                }
                case Rules.FlyWithGoos:
                {
                        spiece.LocateTo(space);
                        Console.WriteLine($"{spiece.PiecePlayer.Name} Fly with goos!");
                        won = StartAction(spiece, MakeTurn(spiece));
                        break;
                }
                case Rules.GoTo12:
                {
                        spiece.LocateTo(Board.Spaces[12]);
                        Console.WriteLine($"{spiece.PiecePlayer.Name} goes to 12!");
                        break;
                }
                case Rules.GoTo39:
                {
                        spiece.LocateTo(Board.Spaces[39]);
                        Console.WriteLine($"{spiece.PiecePlayer.Name} goes to 39!");
                        break;
                }
                case Rules.SkipOneTurn:
                {
                        spiece.LocateTo(space);
                        spiece.LeftRollsToMiss = 2;
                        Console.WriteLine($"{spiece.PiecePlayer.Name} skip one turn!");
                        break;
                }
                case Rules.SkipThreeTurns:
                {
                        spiece.LocateTo(space);
                        spiece.LeftRollsToMiss = 4;
                        Console.WriteLine($"{spiece.PiecePlayer.Name} skip three turns!");
                        break;
                }
                case Rules.WaitUntilAnotherArrives:
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
                        break;
                }
                case Rules.WinnerStopGame:
                {
                        Console.WriteLine($"Game Over {spiece.PiecePlayer.Name} won!");
                        won = true;
                        break;
                }
            }
            return won;

        }
        private ISpace MakeTurn(Piece current)
        {
           
            int forwardIndex = current.PieceCurrentSpace.Index + SpaceForward;
            int maxIndex = this.Board.MaxIndex;
            if(forwardIndex >= maxIndex)
            { 
                forwardIndex = maxIndex - (forwardIndex - maxIndex); 
            }
            ISpace space = this.Board.Spaces[forwardIndex];
            Console.WriteLine($"Piece {current.PiecePlayer.Name} {current.PieceCurrentSpace.Index} with {SpaceForward} eyes ({this.Board.DiceRoller.Scoores[0].ToString()}+{this.Board.DiceRoller.Scoores[1].ToString()}) relocate to {space.Name} {space.Index} with {space.Action}");
           
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