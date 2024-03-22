Console.WriteLine("What's your Name?");
Console.Write("> ");
string name = Console.ReadLine();
int score = 0;
if (File.Exists($"{name}.txt")) {
    score = int.Parse(File.ReadAllText($"{name}.txt"));
}





while (true) {
    
    Console.Write("> ");
    ConsoleKey key = Console.ReadKey().Key;
    if (key == ConsoleKey.Enter) {
        File.WriteAllText($"{name}.txt", score.ToString());
        break;
    }
    score++;
    Console.WriteLine($"\nYour score is {score}.");
}


