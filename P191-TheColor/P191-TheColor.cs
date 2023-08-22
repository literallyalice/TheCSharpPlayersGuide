Color myColor = new Color(255, 17, 22);
Color mySecondColor = Color.Pink;

Console.WriteLine($"My Color: R:{myColor.R}, G:{myColor.G}, B:{myColor.B}");
Console.WriteLine($"My Second Color: R: {mySecondColor.R}, G:{mySecondColor.G}, B:{mySecondColor.B}");


class Color
{
    public int R { get; }
    public int G { get; }
    public int B { get; }

    public static Color Red => new Color(255, 0, 0);
    public static Color Green => new Color(0, 255, 0);
    public static Color Blue => new Color(0, 0, 255);
    
    public static Color Teal => new Color(0, 255, 255);
    public static Color Pink => new Color(255, 51, 255);
    public static Color Yellow => new Color(255, 255, 51);
    public static Color Orange => new Color(255, 128, 0);
    public static Color Black => new Color(0, 0, 0);
    public static Color White => new Color(255, 255, 255);

    public Color(int r, int g, int b) {
        R = r;
        G = g;
        B = b;
    }

    public Color() {
        R = G = B = 0;
    }
    
}