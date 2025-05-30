using System.Drawing;
using System.Dynamic;

dynamic robot = new ExpandoObject();
int i = 1;
while (true)
{
    Init(i);
    Console.WriteLine("----------------");
    foreach (KeyValuePair<string, object> property in (IDictionary<string, object>)robot)
    {
        Console.WriteLine($"{property.Key}: {property.Value}");
    }
    i++;
    Console.WriteLine("---------------");
}

return;

void Init(int id)
{ 
    Console.WriteLine($"You are configuring robot #{id}.");
    robot.ID = id;
    Console.WriteLine("Do you want to name this robot?");
    if (YesNoToBool(Console.ReadLine()))
    {
        Console.WriteLine("What is his name?");
        robot.Name = Console.ReadLine();
    }

    Console.WriteLine("Does this robot have a specific size?");
    if (YesNoToBool(Console.ReadLine()))
    {
        Console.WriteLine("What is its height?");
        robot.Height = int.Parse(Console.ReadLine()!);
        Console.WriteLine("What is its width?");
        robot.Width = int.Parse(Console.ReadLine()!);
    }

    Console.WriteLine("Does this robot have a specific color?");
    if (YesNoToBool(Console.ReadLine()))
    {
        Console.WriteLine("What is its color?");
        robot.Color = Color.FromName(Console.ReadLine()!);
    }
}

bool YesNoToBool(string? input)
{
    return input is "yes" or "y";
}




