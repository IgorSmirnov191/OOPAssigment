namespace GooseGame
{
    public class WellSpace : ISpace
    {
        public WellSpace(int index)
        {
            Index = index;
        }

        public WellSpace(SpaceTypes type)
        {
            Index = (int)type;
        }

        public int Index { get; set; }
        public string Name { get; set; } = "Well";
        public SpaceTypes Type { get; set; } = SpaceTypes.WellSpace;
        public Rules.ActionRules Action { get; set; } = Rules.ActionRules.WaitUntilAnotherArrives;
    }
}