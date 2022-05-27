namespace GooseGame
{
    public class StartSpace : StaticSpace
    {
        public StartSpace(int index) : base(index)
        {
            Name = "Start";
        }

        public StartSpace(SpaceTypes type) : base(type)
        {
            Name = "Start";
        }
    }
}