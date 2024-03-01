




public static class RandomExtensions
{
    public static double NextDouble(this Random random, double max) {
        return random.NextDouble() * max;
    }

    public static string NextString(this Random random, params string[] input) {
        return input[random.Next(0, input.Length)];
    }

    public static bool CoinFlip(this Random random, float headsChance = 0.5f) {
        return random.NextDouble() < headsChance;
    }
}