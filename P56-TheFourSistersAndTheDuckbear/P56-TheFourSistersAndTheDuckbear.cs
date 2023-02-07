const int sisters = 4;

Console.WriteLine("The Sisters' Egg Divider");
Console.Write("Egg amount: ");
var eggs = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("The sisters get " + eggs / sisters + " egg(s) each.");
Console.WriteLine("The duckbear gets " + eggs % sisters + " egg(s).");

