Console.WriteLine("Welcome, select a sieve. (1. IsEven, 2. IsPositive, 3. IsMultipleOfTen)");
Console.Write("> ");
int.TryParse(Console.ReadLine(), out int input);

var mySieve = input switch
{
    1 => new Sieve(n => n % 2 == 0),
    2 => new Sieve(n => n > 0),
    3 => new Sieve(n => n % 10 == 0),
    _ => throw new ArgumentOutOfRangeException()
};

while (true) {
    Console.WriteLine("Enter a number: ");
    int.TryParse(Console.ReadLine(), out int numInput);

    Console.WriteLine(mySieve.IsGood(numInput) ? $"{numInput} is good." : $"{numInput} is bad.");
}

class Sieve(Func<int, bool> input)
{
    public bool IsGood(int number) => input(number);
}