namespace GooseGame
{
    public class Shape : IShape
    {
        public string Name { get; set; }
        public string Picture { get; set; }

        public Shape(string name, string picture)
        {
            Name = name;
            Picture = picture;
        }
    }
}