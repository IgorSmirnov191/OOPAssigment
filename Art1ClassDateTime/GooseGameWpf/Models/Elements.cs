using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace GooseGameWpf.Models
{
    public enum GameStatus { None, Idle, Error, Abort };
    public enum PiecesColour { Blue = 9, Green, Red = 12, Yellow = 14 };
    public class Elements
    {
        public GameStatus GameCurrentStatus { get; set; } = GameStatus.None;

        public static IDictionary<PiecesColour, string> spieceIcons = new Dictionary<PiecesColour, string>
        {
                { PiecesColour.Blue, "Images/PieceBlue.png" },
                { PiecesColour.Green, "Images/PieceGreen.png" },
                { PiecesColour.Red, "Images/PieceRed.png" },
                { PiecesColour.Yellow, "Images/PieceYellow.png" },

        };

        public static IDictionary<int, string> diceIcons = new Dictionary<int, string>
        {
                { 0,"Images/PieceDefault.png" },
                { 1, "Images/DiceOne.png" },
                { 2, "Images/DiceTwo.png" },
                { 3, "Images/DiceThree.png" },
                { 4, "Images/DiceFour.png" },
                { 5, "Images/DiceFive.png" },
                { 6, "Images/DiceSix.png" },

        };
        public static IDictionary<int, IList<Point>> spieceParking = new Dictionary<int, IList<Point>>
        {
                { 0, new List<Point> { new Point(9,8), new Point(9,9), new Point(10,8), new Point(10,9) } }, //Parking
                { 1, new List<Point> { new Point(18,6), new Point(18,7), new Point(19,6), new Point(19,7) } }, //Start
                { 2, new List<Point> { new Point(18,9), new Point(18,10), new Point(19,9), new Point(19,10) } },
                { 3, new List<Point> { new Point(18,11), new Point(18,12), new Point(19,11), new Point(19,12) } },
                { 4, new List<Point> { new Point(18,13), new Point(18,14), new Point(19,13), new Point(19,14) } },
                { 5, new List<Point> { new Point(19,16), new Point(19, 16), new Point(19, 16), new Point(19, 16) } }, //Goose
                { 6, new List<Point> { new Point(18,18), new Point(18, 18), new Point(18, 18), new Point(18, 18) } }, //Bridge
                { 7, new List<Point> { new Point(18,20), new Point(19,20), new Point(20,20), new Point(19,21) } },
                { 8, new List<Point> { new Point(18,22), new Point(19,22), new Point(20,22), new Point(19,23) } },
                { 9, new List<Point> { new Point(18,25), new Point(18, 25), new Point(18, 25), new Point(18, 25) } }, //Goose
                { 10, new List<Point> { new Point(16,26), new Point(16,27), new Point(17,26), new Point(17,27) } },
                { 11, new List<Point> { new Point(14,27), new Point(15,27), new Point(15,28), new Point(16,28) } },
                { 12, new List<Point> { new Point(13,27), new Point(13,28), new Point(13,29), new Point(14,29) } },
                { 13, new List<Point> { new Point(11,28), new Point(11,29), new Point(11,30), new Point(12,29) } },
                { 14, new List<Point> { new Point(9,29), new Point(9, 29), new Point(9, 29), new Point(9, 29) } }, //Goose
                { 15, new List<Point> { new Point(7,28), new Point(7,29), new Point(8,28), new Point(8,29) } },
                { 16, new List<Point> { new Point(6,27), new Point(5,28), new Point(6,28), new Point(5,29) } },
                { 17, new List<Point> { new Point(4,26), new Point(3,27), new Point(4,27), new Point(4,28) } },
                { 18, new List<Point> { new Point(2,24), new Point(2, 24), new Point(2, 24), new Point(2, 24) } }, //Goose
                { 19, new List<Point> { new Point(1,21), new Point(1,22), new Point(2,21), new Point(2,22) } }, //Inn
                { 20, new List<Point> { new Point(1,19), new Point(1,20), new Point(2,19), new Point(2,20) } },
                { 21, new List<Point> { new Point(1,17), new Point(1,18), new Point(2,17), new Point(2,18) } },
                { 22, new List<Point> { new Point(1,15), new Point(1,16), new Point(2,15), new Point(2,16) } },
                { 23, new List<Point> { new Point(1,13), new Point(1, 13), new Point(1, 13), new Point(1, 13) } }, //Goose
                { 24, new List<Point> { new Point(1,11), new Point(1,12), new Point(2,11), new Point(2,12) } },
                { 25, new List<Point> { new Point(1,9), new Point(1,10), new Point(2,9), new Point(2,10) } },
                { 26, new List<Point> { new Point(1,7), new Point(1,8), new Point(2,7), new Point(2,8) } },
                { 27, new List<Point> { new Point(2,5), new Point(2, 5), new Point(2,5), new Point(2, 5) } }, //Goose
                { 28, new List<Point> { new Point(2,3), new Point(2,4), new Point(3,3), new Point(3,4) } },
                { 29, new List<Point> { new Point(4,2), new Point(2,4), new Point(5,3), new Point(5,4) } },
                { 30, new List<Point> { new Point(5,1), new Point(6,1), new Point(6,2), new Point(6,3) } },
                { 31, new List<Point> { new Point(7,1), new Point(8,0), new Point(8,1), new Point(8,2) } },  //Well
                { 32, new List<Point> { new Point(10,2), new Point(10, 2), new Point(10, 2), new Point(10, 2) } }, //Goose
                { 33, new List<Point> { new Point(11,2), new Point(11,3), new Point(12,1), new Point(12,2) } },
                { 34, new List<Point> { new Point(14,2), new Point(14,3), new Point(13,3), new Point(13,4) } },
                { 35, new List<Point> { new Point(15,3), new Point(14,4), new Point(15,4), new Point(14,5) } },
                { 36, new List<Point> { new Point(16,6), new Point(16, 6), new Point(16, 6), new Point(16, 6) } }, //Goose
                { 37, new List<Point> { new Point(17,7), new Point(15,8), new Point(16,8), new Point(17,8) } },
                { 38, new List<Point> { new Point(15,9), new Point(15,10), new Point(16,9), new Point(16,10) } },
                { 39, new List<Point> { new Point(15,11), new Point(15,12), new Point(16,11), new Point(16,12) } },
                { 40, new List<Point> { new Point(15,13), new Point(15,14), new Point(16,13), new Point(16,14) } },
                { 41, new List<Point> { new Point(16,16), new Point(16,16), new Point(16,16), new Point(16,16) } }, //Goose
                { 42, new List<Point> { new Point(16,17), new Point(15,18), new Point(16,18), new Point(17,18) } }, //Maze
                { 43, new List<Point> { new Point(16,20), new Point(16,20), new Point(17,20), new Point(17,21) } },
                { 44, new List<Point> { new Point(15,22), new Point(16,22), new Point(17,22), new Point(16,23) } },
                { 45, new List<Point> { new Point(14,24), new Point(14, 24), new Point(14, 24), new Point(14, 24) } }, //Goose
                { 46, new List<Point> { new Point(12,24), new Point(12,25), new Point(12,26), new Point(13,26) } },
                { 47, new List<Point> { new Point(11,25), new Point(11,26), new Point(11,27), new Point(10,27) } },
                { 48, new List<Point> { new Point(9,25), new Point(9,26), new Point(9,27), new Point(8,27) } },
                { 49, new List<Point> { new Point(8,24), new Point(8,25), new Point(7,25), new Point(7,26) } },
                { 50, new List<Point> { new Point(5,24), new Point(5, 24), new Point(5, 24), new Point(5, 24) } }, //Goose
                { 51, new List<Point> { new Point(4,21), new Point(4,22), new Point(5,21), new Point(5,22) } },
                { 52, new List<Point> { new Point(4,18), new Point(4,19), new Point(5,18), new Point(5,19) } }, //Prison
                { 53, new List<Point> { new Point(4,15), new Point(3,16), new Point(4,16), new Point(5,16) } },
                { 54, new List<Point> { new Point(4,13), new Point(4, 13), new Point(4, 13), new Point(4, 13) } }, //Goose
                { 55, new List<Point> { new Point(3,11), new Point(3,12), new Point(4,11), new Point(4,12) } },
                { 56, new List<Point> { new Point(4,9), new Point(4,10), new Point(5,9), new Point(5,10) } },
                { 57, new List<Point> { new Point(4,7), new Point(3,8), new Point(4,8), new Point(5,8) } },
                { 58, new List<Point> { new Point(6,5), new Point(6,6), new Point(7,5), new Point(7,6) } }, //Death
                { 59, new List<Point> { new Point(9,5), new Point(9, 5), new Point(9, 5), new Point(9, 5) } }, //Goose
                { 60, new List<Point> { new Point(11,4), new Point(11,5), new Point(11,6), new Point(10,4) } },
                { 61, new List<Point> { new Point(13,6), new Point(12,6), new Point(12,7), new Point(11,7) } },
                { 62, new List<Point> { new Point(13,7), new Point(12,8), new Point(13,8), new Point(14,8) } },
                { 63, new List<Point> { new Point(10,15), new Point(10,15), new Point(10,15), new Point(10,15) } } //End


        };
    }
}
