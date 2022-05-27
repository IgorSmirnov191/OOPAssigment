namespace GooseGame
{
    public class StaticSpace : ISpace
    {
        public StaticSpace(int index)
        {
            Index = index;
            Name = index.ToString();
        }

        public StaticSpace(SpaceTypes type)
        {
            Index = (int)type;
        }

        public int Index { get; set; }
        public string Name { get; set; }
        public Rules.ActionRules Action { get; set; } = Rules.ActionRules.None;
        public SpaceTypes Type { get; set; } = SpaceTypes.StaticSpace;
    }
}