using System.Collections.Generic;

namespace GooseGame
{
    public class Rules
    {
        public enum ActionRules
        {
            Unknown, None, FlyWithGoos, GoToStart, GoTo12, GoTo39, SkipOneTurn, SkipThreeTurns, WaitUntilAnotherArrives, WinnerStopGame
        }

        public static Dictionary<string, IList<int>> spaceRules = new Dictionary<string, IList<int>>
    {
            { "StartSpace", new List<int> { 1 } },
            { "StaticSpace",new List<int> {  0, 2,  3,  4,  7,  8,  10,
                                            11, 12, 13, 15, 16, 17, 20,
                                            21, 22, 24, 25, 26, 28, 29, 30,
                                            33, 34, 35, 37, 38, 39, 40,
                                            43, 44, 46, 47, 48, 49,
                                            51, 53, 55, 56, 57,
                                            60, 61, 62 } },
            { "GooseSpace", new List<int> { 5, 9, 14, 18, 23, 27, 32, 36, 41, 45, 50, 54, 59 } },
            { "BridgeSpace",new List<int> { (int)SpaceTypes.BridgeSpace } },
            { "InnSpace",   new List<int> { (int)SpaceTypes.InnSpace } },
            { "WellSpace",  new List<int> { (int)SpaceTypes.WellSpace } },
            { "MazeSpace",  new List<int> { (int)SpaceTypes.MazeSpace } },
            { "PrisonSpace",new List<int> { (int)SpaceTypes.PrisonSpace } },
            { "DeathSpace", new List<int> { (int)SpaceTypes.DeathSpace } },
            { "EndSpace",   new List<int> { 63 } }
    };
    }
}