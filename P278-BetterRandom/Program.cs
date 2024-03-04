var random = new Random();

Console.WriteLine(random.NextDouble(100));
Console.WriteLine(random.NextString("Knight", "Queen", "King"));
Console.WriteLine(random.CoinFlip());
Console.WriteLine(random.CoinFlip(0.25f));

public static class RandomExtensions
{
    public static double NextDouble(this Random random, double max) 
        => random.NextDouble() * max;
    

    public static string NextString(this Random random, params string[] input) 
        => input[random.Next(0, input.Length)];
    

    public static bool CoinFlip(this Random random, float headsProbability = 0.5f) 
        => random.NextDouble() < headsProbability;
} 