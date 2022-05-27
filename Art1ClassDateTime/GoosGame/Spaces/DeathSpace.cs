namespace GooseGame
{
    public class DeathSpace : ISpace
    {
        public DeathSpace(int index)
        {
            Index = index;
        }

        public DeathSpace(SpaceTypes type)
        {
            Index = (int)type;
        }

        public int Index { get; set; }
        public string Name { get; set; } = "Death";
        public SpaceTypes Type { get; set; } = SpaceTypes.DeathSpace;
        public Rules.ActionRules Action { get; set; } = Rules.ActionRules.GoToStart;
    }
}