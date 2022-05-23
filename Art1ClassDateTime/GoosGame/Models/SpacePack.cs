using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame
{

    public class SpacePack
    {
        public List<int>  GooseArray = new List<int>{ 5, 9, 14, 18, 23, 27, 32, 36, 41, 45, 50, 54, 59 };
        public List<ISpace> Spaces { get; set; } = new List<ISpace>();
        public int MaxIndexOfBoard { get; set; }

        public SpacePack(int maxindex)
        {
            MaxIndexOfBoard = maxindex;
            AddBoardSpaces();
        }
        public void AddBoardSpaces()
        {
            Spaces.Add(new StaticSpace(0, null));

            for (int i = 1; i <= MaxIndexOfBoard; i++)
            {
                if (GooseArray.IndexOf(i) != -1)
                {
                    Spaces.Add(new GooseSpace(i, null));
                }
                else if (i == (int)SpaceTypes.BridgeSpace)
                {
                    Spaces.Add(new BridgeSpace(null));
                }
                else if (i == (int)SpaceTypes.InnSpace)
                {
                    Spaces.Add(new InnSpace(null));
                }
                else if (i == (int)SpaceTypes.WellSpace)
                {
                    Spaces.Add(new WellSpace(null));
                }
                else if (i == (int)SpaceTypes.MazeSpace)
                {
                    Spaces.Add(new MazeSpace(null));
                }
                else if (i == (int)SpaceTypes.PrisonSpace)
                {
                    Spaces.Add(new PrisonSpace(null));
                }
                else if (i == (int)SpaceTypes.DeathSpace)
                {
                    Spaces.Add(new DeathSpace(null));
                }
                else if (i == (int)SpaceTypes.StartSpace)
                {
                    Spaces.Add(new StartSpace(i, null));
                }
                else if (i == (int)SpaceTypes.EndSpace)
                {
                    Spaces.Add(new EndSpace(null));
                }
                else
                {
                    Spaces.Add(new StaticSpace(i, null));
                }
            }
        }
    }
}
