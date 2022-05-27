namespace GooseGame
{
    public class PrisonSpace : ISpace
    {
        public PrisonSpace(int index)
        {
            Index = index;
        }

        public PrisonSpace(SpaceTypes type)
        {
            Index = (int)type;
        }

        public int Index { get; set; }
        public string Name { get; set; } = "Prison";
        public SpaceTypes Type { get; set; } = SpaceTypes.PrisonSpace;
        public Rules.ActionRules Action { get; set; } = Rules.ActionRules.SkipThreeTurns;
    }
}