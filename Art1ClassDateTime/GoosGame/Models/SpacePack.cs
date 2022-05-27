using System;
using System.Collections.Generic;
using System.Linq;

namespace GooseGame
{
    public class SpacePack
    {
        public IList<ISpace> Spaces { get; set; } = new List<ISpace>();
        public int MaxIndexOfBoard { get; set; }

        public SpacePack(int maxindex)
        {
            MaxIndexOfBoard = maxindex;
            AddBoardSpaces();
        }

        public void AddBoardSpaces()
        {
            for (int i = 0; i <= MaxIndexOfBoard; i++)
            {
                foreach (var rule in Rules.spaceRules)
                {
                    if (rule.Value.ToList().IndexOf(i) != -1)
                    {
                        Spaces.Add(GetSpace(rule.Key, i));
                    }
                }
            }
        }

        public static ISpace GetSpace(string spaceType, int index)
        {
            try
            {
                return (ISpace)Activator.CreateInstance(Type.GetType($"GooseGame.{spaceType}"), new Object[] { index });
            }
            catch (Exception e)
            {
                return new StaticSpace(index);
            }
        }
    }
}