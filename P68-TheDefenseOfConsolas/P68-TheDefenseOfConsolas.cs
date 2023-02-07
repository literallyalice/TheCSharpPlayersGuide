int targetRow;
int targetColumn;

Console.Title = "--- The Defense of Consolas ---";
Console.WriteLine("--- The Defense of Consolas ---");

Console.Write("Target column: ");
targetColumn = Convert.ToInt32(Console.ReadLine());
Console.Write("Target row: ");
targetRow = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Deploy to: ");
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine($"       ({targetColumn} , {targetRow+1})    ");
Console.Write($"({targetColumn - 1} , {targetRow})");
Console.ForegroundColor = ConsoleColor.Green;
Console.Write("   x   ");
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine($"{targetColumn + 1} , {targetRow})");
Console.WriteLine($"       ({targetColumn} , {targetRow-1})");

Console.Beep();