
var basicSword = new Sword(SwordType.Iron, GemType.None, 1.6f, 0.1f);
var serpentBreath = basicSword with { Gem = GemType.Amber, Type = SwordType.Steel };
var sapphiroth = basicSword with { Gem = GemType.Sapphire, Type = SwordType.Binarium };

Console.WriteLine(basicSword);
Console.WriteLine(serpentBreath);
Console.WriteLine(sapphiroth);

record Sword(SwordType Type, GemType Gem, float Length, float Width);

enum SwordType
{
    Wood,
    Bronze,
    Iron,
    Steel,
    Binarium
}

enum GemType
{
    Emerald,
    Amber,
    Sapphire,
    Diamond,
    Bitstone,
    None
}