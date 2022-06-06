using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GooseGame;
using GooseGameWpf.Models;
using System.Windows.Media;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GooseGameWpf.ViewModels
{
    internal class GameViewModel: INotifyPropertyChanged
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
                if(_scoorOne != value)
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
                if(value != _gameOver)
                {
                    _gameOver = value;
                    OnPropertyChanged();
                }
            
            }
        }
        public ConsoleColor GameOverColour { get; set;}
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
            return Game.ActiveBoard.Start();
        }

        public void BoardToParking()
        {
            Game.ActiveBoard.Stop();
        }
        public bool Roll() 
        {
            bool result = Game.ActiveBoard.Roll();
            if(result)
            {
               
                GameOver = $"{CurrentSpiece.PiecePlayer.Name} is winner. Game over.";
            }
            else
            {
                GameOver = $"{CurrentSpiece.PiecePlayer.Name} locate to Space {CurrentSpiece.PieceCurrentSpace.Index}";
            }
            GameOverColour = CurrentSpiece.Colour;
            ScoorOne = Elements.diceIcons[Game.ActiveBoard.DiceRoller.Scoores[0]];
            ScoorTwo = Elements.diceIcons[Game.ActiveBoard.DiceRoller.Scoores[1]];
            return result;
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
          
            foreach(var piece in Game.ActiveBoard.Pieces)
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
            switch(concolor)
            {
                case ConsoleColor.Blue:
                   return Color.FromRgb(0,0,0xff);
                case ConsoleColor.Green:
                   return Color.FromRgb(0,0xff,0);
                case ConsoleColor.Red:
                    return Color.FromRgb(0xff, 0, 0);
                case ConsoleColor.Yellow:
                    return Color.FromRgb(0xff,0xff,0);

            }
            return Color.FromRgb(0,0,0);
        }
        
    }
}
