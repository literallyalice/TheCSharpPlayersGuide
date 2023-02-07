const int estatePoints = 1;
const int duchyPoints = 3;
const int provincePoints = 6;

int score = 0;

Console.WriteLine("The Dominion of Kings");
Console.Write("Estates: ");
var estates = Convert.ToInt32(Console.ReadLine());
Console.Write("Duchies: ");
var duchies = Convert.ToInt32(Console.ReadLine());
Console.Write("Provinces: ");
var provinces = Convert.ToInt32(Console.ReadLine());

score = (estates * estatePoints) + (duchies * duchyPoints) + (provinces * provincePoints);
Console.WriteLine("--------");
Console.WriteLine("Your kingdom is worth " + score + " points.");