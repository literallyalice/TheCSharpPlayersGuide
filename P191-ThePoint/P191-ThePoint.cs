Point myPoint = new Point(2, 3);
Point yourPoint = new Point(-4, 0);

Console.WriteLine($"My point is ({myPoint.X}, {myPoint.Y}).");
Console.Write($"Your point is ({yourPoint.X}, {yourPoint.Y}).");

class Point
{
    public float X { get; }
    public float Y { get; }

    public Point(float x, float y) {
        X = x;
        Y = y;
    }

    public Point() : this(0,0) { }
}