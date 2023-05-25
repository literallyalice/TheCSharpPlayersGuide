Console.WriteLine("--- Simula's Soup ---");
(SoupType soupType, Ingredient ingredient, Seasoning seasoning) Soup;


Console.WriteLine("-- Type of Soups --");
Soup.soupType = (SoupType)ChooseFromList(Enum.GetNames(typeof(SoupType)));
Console.WriteLine("-- Main Ingredients --");
Soup.ingredient = (Ingredient)ChooseFromList(Enum.GetNames(typeof(Ingredient)));
Console.WriteLine("-- Seasoning --");
Soup.seasoning = (Seasoning)ChooseFromList(Enum.GetNames(typeof(Seasoning)));

Console.WriteLine("You've ordered a " + Soup.seasoning + " " + Soup.soupType + " with " + Soup.ingredient + ".");


int ChooseFromList(string[] names) {
    var i = 0;
    foreach (string label in names) {
        i++;
        Console.WriteLine(i + ". " + label);
    }
    
    Console.Write("Enter a number: (#) ");
    string? input = Console.ReadLine();
    int number;
    while (!int.TryParse(input, out number) &&
           Convert.ToInt32(input) < names.Length &&
           Convert.ToInt32(input) > 0) {
        Console.WriteLine("Invalid input, please enter a number!");
        Console.Write("Enter a number: (#) ");
        input = Console.ReadLine();
    }
    Console.WriteLine("You selected " + names[number - 1] + ".");

    return number;
}

enum SoupType
{
    Soup = 1,
    Stew,
    Gumbo
}

enum Ingredient
{
    Mushroom = 1,
    Chicken,
    Carrots,
    Potatoes
}

enum Seasoning
{
    Spicy = 1,
    Salty,
    Sweet
}