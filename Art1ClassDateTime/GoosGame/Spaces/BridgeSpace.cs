namespace GooseGame
{
    public class BridgeSpace : ISpace
    {
        public BridgeSpace(int index)
        {
            Index = index;
        }

        public BridgeSpace(SpaceTypes type)
        {
            Index = (int)type;
        }

        public int Index { get; set; }
        public string Name { get; set; } = "Bridge";
        public SpaceTypes Type { get; set; } = SpaceTypes.BridgeSpace;
        public Rules.ActionRules Action { get; set; } = Rules.ActionRules.GoTo12;
    }
}