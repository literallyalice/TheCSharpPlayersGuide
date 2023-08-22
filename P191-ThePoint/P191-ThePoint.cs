Point myPoint = new Point(2, 3);
Point yourPoint = new Point(-4, 0);

Console.WriteLine($"Point 1: {myPoint.X}, {myPoint.Y}.");
Console.WriteLine($"Point 2: {yourPoint.X}, {myPoint.Y}");


class Point
{
    public float X { get; }
    public float Y { get; }

    public Point(float x, float y) {
        X = x;
        Y = y;
    }

    public Point() {
        X = Y = 0;
    }
}