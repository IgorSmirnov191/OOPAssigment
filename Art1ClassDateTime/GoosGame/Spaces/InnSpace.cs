namespace GooseGame
{
    public class InnSpace : ISpace
    {
        public InnSpace(int index)
        {
            Index = index;
        }

        public InnSpace(SpaceTypes type)
        {
            Index = (int)type;
        }

        public int Index { get; set; }
        public string Name { get; set; } = "Inn";
        public SpaceTypes Type { get; set; }
        public Rules.ActionRules Action { get; set; } = Rules.ActionRules.SkipOneTurn;
    }
}