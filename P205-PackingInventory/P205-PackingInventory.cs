Pack pack = new Pack(5, 10, 8);
 
while (true) {
    Console.Clear();
    Console.WriteLine("---Inventory");
    Console.WriteLine("----------------------------------------------------");
    if (pack.Inventory.Count == 0) Console.WriteLine("Your Inventory is empty~");
    else {
        foreach (var item in pack.Inventory) {
            Console.WriteLine($"{item.GetType().Name}       {item.Weight} lbs.      {item.Volume} dm3");
        }
    }
    Console.WriteLine("----------------------------------------------------");
    Console.WriteLine($"{pack.CurrentItems}/{pack.MaxItems} Items " +
                      $"| {pack.CurrentWeight} / {pack.MaxWeight} Weight (lbs) | " +
                      $"{pack.CurrentVolume} / {pack.MaxVolume} Volume (dm3)");
    Console.WriteLine("----------------------------------------------------");
    Console.WriteLine();
    Console.WriteLine("Select an item to add to your pack:");
    Console.WriteLine("1. Arrow \t2. Bow\t\t3. Rope\n4. Water\t5. Food\t\t6. Sword");
    int input = Input(6);
 
    InventoryItem newItem = input switch {
        1 => new Arrow(),
        2 => new Bow(),
        3 => new Rope(),
        4 => new Water(),
        5 => new Food(),
        6 => new Sword(),
        _ => throw new ArgumentOutOfRangeException()
    };
 
    if (!pack.AddInventoryItem(newItem)) {
        Console.WriteLine("Couldn't add this item to the pack.");
        Console.WriteLine("Click any button to continue..");
        Console.ReadKey();
    }
 
}
 
int Input(int choices) {
    int number = 0;
    while (number < 1 || number > choices) {
        number = ValidateInput();
    }
 
    return number;
}
 
int ValidateInput() {
    Console.Write(">");
    string? input = Console.ReadLine();
    var number = 0;
    while (input == null || !int.TryParse(input, out number)) {
        Console.WriteLine("> Invalid input, try again.");
        Console.Write("> ");
        input = Console.ReadLine();
    }
 
    return number;
 
}
 
 
class Pack
{
    public int MaxItems { get; private set; }
    public int CurrentItems { get; private set; }
    public float MaxWeight { get; private set; }
    public float CurrentWeight { get; private set; }
    public float MaxVolume { get; private set; }
    public float CurrentVolume { get; private set; }
    public List<InventoryItem> Inventory { get; private set; }
 
    public Pack(int maxItems, float maxWeight, float maxVolume) {
        MaxItems = maxItems;
        MaxWeight = maxWeight;
        MaxVolume = maxVolume;
        Inventory = new List<InventoryItem>();
    }
 
    public bool AddInventoryItem(InventoryItem item) {
        if (item.Weight + CurrentWeight > MaxWeight ||
            item.Volume + CurrentVolume > MaxVolume ||
            CurrentItems + 1 > MaxItems) {
            return false;
        }
        else {
            Inventory.Add(item);
            UpdateInventory();
            return true;
        }
    }
 
    private void UpdateInventory() {
        CurrentWeight = Inventory.Sum(item => item.Weight);
        CurrentVolume = Inventory.Sum(item => item.Volume);
        CurrentItems = Inventory.Count;
 
    }
    
}
 
class InventoryItem
{
    
    public float Weight { get; private set; }
    public float Volume { get; private set; }
    
    
    public InventoryItem(float weight, float volume) {
        Weight = weight;
        Volume = volume;
    }
}
 
class Arrow : InventoryItem { public Arrow() : base(0.1f, 0.05f) { } }
class Bow : InventoryItem { public Bow() : base(1f, 4f) { } }
class Rope : InventoryItem { public Rope() : base(1f, 1.5f) { } }
class Water : InventoryItem { public Water() : base(2f, 3f) { } }
class Food : InventoryItem { public Food() : base(1f, 0.5f) { } }
class Sword : InventoryItem { public Sword() : base(5f, 3f) { } }