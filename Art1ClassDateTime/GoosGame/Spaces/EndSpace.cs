namespace GooseGame
{
    public class EndSpace : ISpace
    {
        public EndSpace(int index)
        {
            Index = index;
        }

        public EndSpace(SpaceTypes type)
        {
            Index = (int)type;
        }

        public int Index
        {
            get; set;
        }

        public string Name { get; set; } = "Game Over";
        public SpaceTypes Type { get; set; } = SpaceTypes.EndSpace;
        public Rules.ActionRules Action { get; set; } = Rules.ActionRules.WinnerStopGame;
    }
}