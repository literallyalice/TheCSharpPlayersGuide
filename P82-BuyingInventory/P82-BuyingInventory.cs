Console.Write("The following items are available: \n " +
              "1. Rope\n" +
              "2. Torches\n" +
              "3. Climbing Equipment\n" +
              "4. Clean Water\n" +
              "5. Machete\n" +
              "6. Canoe\n" +
              "7. Food Supplies\n");

Console.WriteLine("What number do you want to see the price of?");
Console.Write("> ");
var choice = Convert.ToInt32(Console.ReadLine());

var price = choice switch
{
    1 => 10,
    2 => 16,
    3 => 24,
    4 => 2,
    5 => 20,
    6 => 200,
    7 => 2,
    _ => 0
};

Console.WriteLine(price > 0 ? $"That item costs {price} gold." : "I'm afraid that item is not in stock!");