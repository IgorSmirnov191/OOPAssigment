namespace GooseGame
{
    public interface ISpace
    {
        int Index { get; set; }
        string Name { get; set; }
        SpaceTypes Type { get; set; }
        Rules.ActionRules Action { get; set; }
    }
}