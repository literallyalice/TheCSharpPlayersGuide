﻿Console.WriteLine("--- Vin Fletcher's Arrows ---");
Arrow arrow;



ArrowMenu();
Console.WriteLine($"The cost of your arrow is {arrow.GetCost()} gold.");

void ArrowMenu() {
    Console.WriteLine("Select one of our bestselling arrows or create a custom one!");
    Console.WriteLine("1. The Elite Arrow, Steel Arrowhead, Plastic Fletching, 95 cm shaft.");
    Console.WriteLine("2. The Beginner Arrow, Wood Arrowhead, Goose Feathers, 75 cm shaft.");
    Console.WriteLine("3. The Marksman Arrow, Steel Arrowhead, Goose Feathers, 65 cm shaft.");
    Console.WriteLine("4. Create Custom Arrow.");
    Console.Write("> ");
    int choice = GetIntWithinRange(1, 4);
    switch (choice) {
        case 1:
            arrow = Arrow.CreateEliteArrow();
            break;
        case 2:
            arrow = Arrow.CreateBeginnerArrow();
            break;
        case 3:
            arrow = Arrow.CreateMarksmanArrow();
            break;
        case 4:
            arrow = GetCustomArrow();
            break;
        default:
            arrow = GetCustomArrow();
            break;
    }
}

Arrow GetCustomArrow() {
    Arrowhead arrowhead = GetArrowhead();
    Fletching fletching = GetFletching();
    float length = GetShaftLength();

    return new Arrow(arrowhead, fletching, length);
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
    while (!int.TryParse(input, out number) ||
           Convert.ToInt32(input) > max ||
           Convert.ToInt32(input) < min) {
        Console.WriteLine($"Invalid input, please enter a number between {min} and {max}.");
        Console.Write("Enter a number: (#) ");
        input = Console.ReadLine();
    }

    return number;
}

class Arrow
{

    public Arrowhead Arrowhead { get; }
    public Fletching Fletching { get; }
    public float Length { get; }

    public static Arrow CreateEliteArrow() {
        return new Arrow(Arrowhead.Steel, Fletching.PlasticFeathers, 95);
    }

    public static Arrow CreateBeginnerArrow() {
        return new Arrow(Arrowhead.Wood, Fletching.GooseFeathers, 75);
    }

    public static Arrow CreateMarksmanArrow() {
        return new Arrow(Arrowhead.Steel, Fletching.GooseFeathers, 65);
    }
    
    public Arrow(Arrowhead arrowhead, Fletching fletching, float length) {
        Arrowhead = arrowhead;
        Fletching = fletching;
        Length = length;
    }
    
    public float GetCost() {
        float arrowheadCost = Arrowhead switch {
            Arrowhead.Steel => 10f,
            Arrowhead.Obsidian => 5f,
            Arrowhead.Wood => 3f,
            _ => 0f
        };

        float fletchingCost = Fletching switch {
            Fletching.PlasticFeathers => 10f,
            Fletching.TurkeyFeathers => 5f,
            Fletching.GooseFeathers => 3f,
            _ => 0f
        };

        float shaftCost = Length * 0.05f;

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