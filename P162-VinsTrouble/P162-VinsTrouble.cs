

Console.WriteLine("--- Vin Fletcher's Arrows ---");

Arrow arrow = GetArrow();
Console.WriteLine($"The cost of your arrow is {arrow.GetCost()} gold.");

Arrow GetArrow() {
    Arrowhead arrowhead = GetArrowhead();
    Fletching fletching = GetFletching();
    float shaftLength = GetShaftLength();

    return new Arrow(arrowhead, fletching, shaftLength);
}

Arrowhead GetArrowhead() {
    Console.WriteLine("Select an arrowhead for your arrow: (1-3) ");
    Arrowhead[] arrowheads = (Arrowhead[])Enum.GetValues(typeof(Arrowhead));
    foreach (Arrowhead text in arrowheads)
    {
        Console.WriteLine($"{(int)text + 1}. {text}");
    }

    Console.Write("> ");
    return (Arrowhead)GetIntWithinRange(1, arrowheads.Length) - 1;

}

Fletching GetFletching() {
    Console.WriteLine("Select a fletching for your arrow: (1-3) ");
    Fletching[] fletchers = (Fletching[])Enum.GetValues(typeof(Fletching));
    foreach (Fletching text in fletchers)
    {
        Console.WriteLine($"{(int)text + 1}. {text}");
    }

    Console.Write("> ");
    return (Fletching)GetIntWithinRange(1, fletchers.Length) - 1;
}

int GetShaftLength() {
    int min = 30;
    int max = 120;
    Console.WriteLine($"Select a shaft length for your arrow({min}cm to {max}cm)");
    Console.Write("> ");
    return GetIntWithinRange(min, max);
}

int GetIntWithinRange(int min, int max) {
    string? input = Console.ReadLine();
    int number;
    while (!int.TryParse(input, out number) &&
           Convert.ToInt32(input) <= max &&
           Convert.ToInt32(input) >= min) {
        Console.WriteLine($"Invalid input, please enter a number between {min} and {max}.");
        Console.Write("Enter a number: (#) ");
        input = Console.ReadLine();
    }

    return number;
}

class Arrow
{
    private Arrowhead _arrowhead;
    private Fletching _fletching;
    private float _shaftLength;

    public Arrowhead GetArrowhead() => _arrowhead;
    public Fletching GetFletching() => _fletching;
    public float GetShaftLength() => _shaftLength;
    
    public Arrow(Arrowhead arrowhead, Fletching fletching, float shaftLength) {
        _arrowhead = arrowhead;
        _fletching = fletching;
        _shaftLength = shaftLength;
    }
    
    public float GetCost() {
        float arrowheadCost = _arrowhead switch {
            Arrowhead.Steel => 10f,
            Arrowhead.Obsidian => 5f,
            Arrowhead.Wood => 3f,
            _ => 0f
        };

        float fletchingCost = _fletching switch {
            Fletching.PlasticFeathers => 10f,
            Fletching.TurkeyFeathers => 5f,
            Fletching.GooseFeathers => 3f,
            _ => 0f
        };

        float shaftCost = _shaftLength * 0.05f;

        return arrowheadCost + fletchingCost + shaftCost;
    }
}

enum Arrowhead
{
    Steel,
    Obsidian,
    Wood
}

enum Fletching
{
    PlasticFeathers,
    TurkeyFeathers,
    GooseFeathers
}