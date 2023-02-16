using System.Xml;

Console.Write("User 1, enter a number between 0 and 100: ");
var number = Convert.ToInt32(Console.ReadLine());
int guess;
Console.WriteLine("User 2, guess the number.");
while (number > 100 || number > 0)
{
    Console.Write("Enter your guess: ");
    guess = Convert.ToInt32(Console.ReadLine());
    if (guess == number)
        Console.WriteLine("You guessed the number!");
    if (guess > number)
        Console.WriteLine($"{guess} is too high!");
    if (guess < number)
        Console.WriteLine($"{guess} is too low!");
}