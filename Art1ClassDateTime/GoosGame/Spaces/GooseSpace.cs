namespace GooseGame
{
    public class GooseSpace : ISpace
    {
        public GooseSpace(int index)
        {
            Index = index;
        }

        public GooseSpace(SpaceTypes type)
        {
            Index = (int)type;
        }

        public int Index { get; set; }
        public string Name { get; set; } = "Goose";
        public SpaceTypes Type { get; set; } = SpaceTypes.GooseSpace;
        public Rules.ActionRules Action { get; set; } = Rules.ActionRules.FlyWithGoos;
    }
}