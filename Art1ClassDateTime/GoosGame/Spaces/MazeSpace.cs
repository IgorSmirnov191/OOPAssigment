namespace GooseGame
{
    public class MazeSpace : ISpace
    {
        public MazeSpace(int index)
        {
            Index = index;
        }

        public MazeSpace(SpaceTypes type)
        {
            Index = (int)type;
        }

        public int Index { get; set; }
        public string Name { get; set; } = "Maze";
        public SpaceTypes Type { get; set; } = SpaceTypes.MazeSpace;
        public Rules.ActionRules Action { get; set; } = Rules.ActionRules.GoTo39;
    }
}