CharberryTree tree = new();
#pragma warning disable 
// ReSharper disable once UnusedVariable
Notifier notifier = new(tree);
// ReSharper disable once UnusedVariable
Harvester harvester = new(tree);
#pragma warning restore

while (true) {
    tree.MaybeGrow();
}

public class CharberryTree
{
    private Random _random = new Random();
    public bool Ripe { get; set; }

    public event Action? Ripened;

    public void MaybeGrow() {
        
        // only a tiny chance of ripening each time
        if (_random.NextDouble() < 0.00000001 && !Ripe) {
            Ripe = true;
            Ripened?.Invoke();
        }
    }
}

public class Notifier
{
    public Notifier(CharberryTree tree) {
        tree.Ripened += OnTreeRipened;
    }

    private void OnTreeRipened() {
        Console.WriteLine("A charberry fruit has ripened!");
    }
}

public class Harvester
{
    private int _harvestCount;
    private readonly CharberryTree _tree;
    public Harvester(CharberryTree tree) {
        _tree = tree;
        tree.Ripened += OnTreeRipened;
    }

    private void OnTreeRipened() {
        _harvestCount++;
        _tree.Ripe = false;
        Console.WriteLine($"A charberry fruit has been harvested, for the {Helper.GetNumberWithOrdinalIndicator(_harvestCount)} time.");
    }
}

public static class Helper{
    public static string GetNumberWithOrdinalIndicator(int number) {
        return number switch 
        {
            var n when n % 10 == 1 && n % 100 != 11 => $"{n}st",
            var n when n % 10 == 2 && n % 100 != 12 => $"{n}nd",
            var n when n % 10 == 3 && n % 100 != 13 => $"{n}rd",
            _ => $"{number}th"
        };
    }
}
