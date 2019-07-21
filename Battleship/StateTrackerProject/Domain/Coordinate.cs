namespace StateTrackerProject.Domain
{
    public class Coordinate
    {
        public int X { get; }
        public int Y { get; }

        public readonly string Id;

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
            Id = $"{X}" + $"{Y}";
        }
    }
}
