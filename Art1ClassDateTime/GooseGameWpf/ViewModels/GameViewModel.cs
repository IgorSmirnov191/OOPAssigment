using GooseGame;
using GooseGameWpf.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;

namespace GooseGameWpf.ViewModels
{
    internal class GameViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string DefaultPieceIcon { get; set; } = "Images/PieceDefault.png";
        private string _scoorOne = "Images/DiceSix.png";
        private string _scoorTwo = "Images/DiceThree.png";

        public string ScoorOne
        {
            get { return _scoorOne; }
            set
            {
                if (_scoorOne != value)
                {
                    _scoorOne = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ScoorTwo
        {
            get { return _scoorTwo; }
            set
            {
                if (_scoorTwo != value)
                {
                    _scoorTwo = value;
                    OnPropertyChanged();
                }
            }
        }

        public IList<string> UserNames { get; set; } = new List<string>
        {
            "Player1",
            "Player2",
            "Player3",
            "Player4"
        };

        public string GameName
        {
            get { return Game.Name; }
            set
            {
                if (Game.Name != value)
                {
                    Game.Name = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _gameOver;

        public string GameOver
        {
            get { return _gameOver; }
            set
            {
                if (value != _gameOver)
                {
                    _gameOver = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool InfoAllowed { get; set; } = false;
        public ConsoleColor GameOverColour { get; set; }

        public GameViewModel()
        {
            Game = new Game(new Board(new SpacePack(Rules.MaxSpaceIndex)));
        }

        public Game Game { get; set; }

        public IPiece CurrentSpiece
        {
            get { return Game.ActiveBoard.Sequenser.CurrentPiece; }
        }

        public int GetCurrentUserIndex()
        {
            return Game.ActiveBoard.Pieces.IndexOf(CurrentSpiece);
        }

        public void ClearUsers()
        {
            Game.ActiveBoard.Pieces.Clear();
        }

        public bool BoardToStart()
        {
            var boardToStart = Game.ActiveBoard.Start();
            GameOver = boardToStart.Item2;
            return boardToStart.Item1;
        }

        public void BoardToParking()
        {
            Game.ActiveBoard.Stop();
        }

        public bool Roll()
        {
            var result = Game.ActiveBoard.Roll();
            if (InfoAllowed)
            {
                GameOver = result.Item2;
            }
            Game.ActiveBoard.Sequenser.TurnLog = "";
            if (result.Item1)
            {
                GameOver = $"{CurrentSpiece.PiecePlayer.Name} is winner. Game over. ";
            }

            GameOverColour = CurrentSpiece.Colour;
            ScoorOne = Elements.diceIcons[Game.ActiveBoard.DiceRoller.Scoores[0]];
            ScoorTwo = Elements.diceIcons[Game.ActiveBoard.DiceRoller.Scoores[1]];
            return result.Item1;
        }

        public void AddUser(string Name, PiecesColour color)
        {
            Piece currentPiece = new Piece(new Player(Name));
            currentPiece.Colour = (ConsoleColor)color;
            currentPiece.PieceShape = new Shape(color.ToString(), Elements.spieceIcons[color]);
            Game.ActiveBoard.Pieces.Add(currentPiece);
        }

        public IList<int> GetCurrentDiceScoores()
        {
            return Game.ActiveBoard.DiceRoller.Scoores;
        }

        public Point GetGridCellPointDestination(int spaceIndex, int pieceIndex)
        {
            return Elements.spieceParking[spaceIndex][pieceIndex];
        }

        public int GetPieceIndex(IPiece piece)
        {
            return Game.ActiveBoard.Pieces.IndexOf(piece);
        }

        public void ClearUser(PiecesColour color)
        {
            foreach (var piece in Game.ActiveBoard.Pieces)
            {
                if (piece.Colour == (ConsoleColor)color)
                {
                    Game.ActiveBoard.Pieces.Remove(piece);
                    break;
                }
            }
        }

        public Color GetColorFromConsoleColor(ConsoleColor concolor)
        {
            switch (concolor)
            {
                case ConsoleColor.Blue:
                    return Color.FromRgb(0, 0, 0xff);

                case ConsoleColor.Green:
                    return Color.FromRgb(0x72, 0x8f, 0x02);

                case ConsoleColor.Red:
                    return Color.FromRgb(0xff, 0, 0);

                case ConsoleColor.Yellow:
                    return Color.FromRgb(0xfd, 0xa5, 0x0f);
            }
            return Color.FromRgb(0, 0, 0);
        }
    }
}