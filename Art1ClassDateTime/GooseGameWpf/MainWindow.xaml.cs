using System.Windows;

using System.Windows.Controls;
using GooseGame;
using GooseGameWpf.ViewModels;
using GooseGameWpf.Models;
using System;
using System.Windows.Media.Imaging;
using System.Windows.Media;


namespace GooseGameWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameViewModel viewModel = new GameViewModel();
       
        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
           

        }

        private void StartStopButton_Click(object sender, RoutedEventArgs e)
        {
            lbGameOver.Background = new SolidColorBrush(Colors.White);
            lbGameOver.Foreground = new SolidColorBrush(Color.FromRgb(0,0,0));
            if (!btRollButton.IsEnabled)
            {
                if (viewModel.Game.ActiveBoard.Pieces.Count > 1)
                {
                    btRollButton.IsEnabled = true;
                    btStartStopButton.Content = "Stop";
                    viewModel.BoardToStart();
                    lbGameOver.Content = "Hello to all players";
                    ChangeLogonAccess(false);
                }
                else 
                {
                    lbGameOver.Content = "Min 2 players allowed";
                    return;
                }

            }
            else
            {
                btRollButton.IsEnabled = false;
                btStartStopButton.Content = "Start";
                viewModel.BoardToParking();
                lbGameOver.Content = "";
                ChangeLogonAccess(true);
            }
           
            RefreshAllGridPieceLocation();
        }

        private void ChangeLogonAccess(bool v)
        {
            chbLogonPlayer1.IsEnabled = v;
            chbLogonPlayer2.IsEnabled = v;
            chbLogonPlayer3.IsEnabled = v;
            chbLogonPlayer4.IsEnabled = v;
            txUser1Name.IsEnabled = v;
            txUser2Name.IsEnabled = v;
            txUser3Name.IsEnabled = v;
            txUser4Name.IsEnabled = v;
        }

        private void RollButton_Click(object sender, RoutedEventArgs e)
        {
            btRollButton.IsEnabled = !viewModel.Roll();
            RefreshAllGridRollers(viewModel.ScoorOne, viewModel.ScoorTwo);
            RefreshAllGridPieceLocation();
            lbGameOver.Background = new SolidColorBrush(Colors.LightGray);
            lbGameOver.Foreground = new SolidColorBrush(viewModel.GetColorFromConsoleColor(viewModel.GameOverColour));

            lbGameOver.Content = viewModel.GameOver;
        }

        private void RefreshAllGridRollers(string scoorOne, string scoorTwo)
        {
            Roller1.Source = new BitmapImage(new Uri(scoorOne, UriKind.Relative));
            Roller2.Source = new BitmapImage(new Uri(scoorTwo, UriKind.Relative));
        }

        private void SetGridPieceLocation(IPiece piece, int index)
        {
            MakeIndexBasedRelocation(index,
                viewModel.GetGridCellPointDestination(piece.PieceCurrentSpace.Index, index));
        }   
        private void RefreshAllGridPieceLocation()
        {
            
            for(int i=0; i< viewModel.Game.ActiveBoard.Pieces.Count; i++)
            {
                IPiece piece = viewModel.Game.ActiveBoard.Pieces[i];
                SetGridPieceLocation(piece, i);

            }

        }
        private void MakeIndexBasedRelocation(int index, Point point)
        {

            switch (index) 
            {
                case 0:
                    {
                        Grid.SetRow(PieceParking00, (int)point.X);
                        Grid.SetColumn(PieceParking00, (int)point.Y);
                        break;
                    }
                case 1:
                    {
                        Grid.SetRow(PieceParking01, (int)point.X);
                        Grid.SetColumn(PieceParking01, (int)point.Y);
                        break;
                    }
                case 2:
                    {
                        Grid.SetRow(PieceParking10, (int)point.X);
                        Grid.SetColumn(PieceParking10, (int)point.Y);
                        break;
                    }
                case 3:
                    {
                        Grid.SetRow(PieceParking11, (int)point.X);
                        Grid.SetColumn(PieceParking11, (int)point.Y);
                        break;
                    }
                default:
                    { break; }

            }
        }
        private void CleanUpAllPiecesParking()
        {
            for(int i=0; i<4;i++)
            {
                SetPieceParking(i, new BitmapImage(new Uri(viewModel.DefaultPieceIcon, UriKind.Relative)));

            }

        }
        private void RefreshAllGridPiecesParking()
        {
            CleanUpAllPiecesParking();
            int i = 0;
            foreach(var piece in viewModel.Game.ActiveBoard.Pieces)
            {
                SetPieceParking(i, new BitmapImage(new Uri(viewModel.Game.ActiveBoard.Pieces[i].PieceShape.Picture, UriKind.Relative)));
                i++;
            }


        }
        private void SetPieceParking(int index, ImageSource  source)
        {
            switch(index)
            {
                case 0:
                    {
                        PieceParking00.Source = source;
                        break;
                    }
                case 1: 
                    {
                        PieceParking01.Source = source;
                        break; 
                    }
                case 2:
                    {
                        PieceParking10.Source = source;
                        break;
                    }
                case 3:
                    {
                        PieceParking11.Source = source;
                        break;
                    }
                default:
                    break;
            }

        }
        private void HandleLogUnchecked(object sender, RoutedEventArgs e)
        {
            //
        }

        private void HandleLogCheck(object sender, RoutedEventArgs e)
        {
            //
        }

        private void HandleCheckUser1(object sender, RoutedEventArgs e)
        {
            viewModel.AddUser(txUser1Name.Text, PiecesColour.Blue);
            RefreshAllGridPiecesParking();
        }

        private void HandleUncheckedUser1(object sender, RoutedEventArgs e)
        {
            viewModel.ClearUser(PiecesColour.Blue);
            txUser1Name.Text = viewModel.UserNames[0];
            RefreshAllGridPiecesParking();

        }


        private void HandleCheckUser2(object sender, RoutedEventArgs e)
        {
            viewModel.AddUser(txUser2Name.Text, PiecesColour.Green);
            RefreshAllGridPiecesParking();
        } 
        private void HandleUncheckedUser2(object sender, RoutedEventArgs e)
        {
            viewModel.ClearUser(PiecesColour.Green);
            txUser1Name.Text = viewModel.UserNames[1];
            RefreshAllGridPiecesParking();
        }

        private void HandleCheckUser3(object sender, RoutedEventArgs e)
        {
            viewModel.AddUser(txUser3Name.Text, PiecesColour.Red);
            RefreshAllGridPiecesParking();
        }
        private void HandleUncheckedUser3(object sender, RoutedEventArgs e)
        {
            viewModel.ClearUser(PiecesColour.Red);
            txUser1Name.Text = viewModel.UserNames[2];
            RefreshAllGridPiecesParking();
        }
        private void HandleCheckUser4(object sender, RoutedEventArgs e)
        {
            viewModel.AddUser(txUser4Name.Text, PiecesColour.Yellow);
            RefreshAllGridPiecesParking();
        }
        private void HandleUncheckedUser4(object sender, RoutedEventArgs e)
        {
            viewModel.ClearUser(PiecesColour.Yellow);
            txUser1Name.Text = viewModel.UserNames[3];
            RefreshAllGridPiecesParking();
        }
    }
}
