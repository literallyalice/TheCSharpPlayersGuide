RecentNumbers recentNumbers = new();
Thread thread = new(GenerateNumbers);
thread.Start();
while (true) {
    Console.ReadKey();
    if (recentNumbers.Numbers[0] == recentNumbers.Numbers[1]){
        Console.WriteLine("> Repeating numbers detected!");
    }
    else {
        Console.WriteLine("> No repeating numbers detected.");
    }
}
void GenerateNumbers(){
    while (true){
        Random random = new Random();
        int num = random.Next(0, 9);
        Console.WriteLine("> Number generated: " + num);
        recentNumbers.Add(num);
        Thread.Sleep(1000);
    }
}

class RecentNumbers {

    private readonly object _lock = new object();
    private List<int> _numbers = new List<int>();
    public List<int> Numbers {

        get{
            lock(_lock){
                return _numbers;
            }
        }
    }
    public void Add(int num){
        lock(_lock){
            _numbers.Add(num);
            if (_numbers.Count > 2){
                _numbers.RemoveAt(0);
            }
        }
    }
}