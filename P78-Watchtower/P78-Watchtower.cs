Console.WriteLine("Watchtower");

Console.Write("Enter x: ");
var x = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter y: ");
var y = Convert.ToInt32(Console.ReadLine());

string direction = "";

if (y < 0)      direction += "south";
else if (y > 0) direction += "north";

if (x < 0)      direction += "west";
else if (x > 0) direction += "east";


if (!(x == 0 && y == 0)){
    Console.WriteLine($"The enemy is to the {direction}!");
}
else {
    Console.WriteLine("The enemy is upon us!");
}