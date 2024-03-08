

Console.WriteLine("Welcome, select a sieve. (1. IsEven, 2. IsPositive, 3. IsMultipleOfTen)");
Console.Write("> ");
int.TryParse(Console.ReadLine(), out int input);

Func<int, bool> operation;
var mySieve = input switch
{
    1 => new Sieve(IsEven),
    2 => new Sieve(IsPositive),
    3 => new Sieve(IsMultipleOfTen),
    _ or 0 => throw new ArgumentOutOfRangeException()
};

while (true) {
    Console.WriteLine("Enter a number: ");
    int.TryParse(Console.ReadLine(), out int numInput);

    Console.WriteLine(mySieve.IsGood(numInput) ? $"{numInput} is good." : $"{numInput} is bad.");
}

bool IsEven(int number) => number % 2 == 0;
bool IsPositive(int number) => number >= 0;
bool IsMultipleOfTen(int number) => number % 10 == 0;

class Sieve(Func<int, bool> input)
{
    public bool IsGood(int number) => input(number);
}