

var oatmeal = new Random().Next(0,9);
var takenNumbers = new List<int>();
bool gameOver = false;

while (!gameOver) {
    Console.WriteLine("Select a number between 0 and 9.");
    Console.Write("> ");
    var input = Console.ReadLine();
    
    if (!int.TryParse(input, out int num)) {
        Console.WriteLine("Enter a valid number.");
        continue;
    }

    if (takenNumbers.Contains(num)) {
        Console.WriteLine($"Cookie #{num} is taken.");
        continue;
    }
    
    takenNumbers.Add(num);
    
    try {
        if (num == oatmeal) {
            throw new OatmealException();
        }
    }
    catch(OatmealException) {
        Console.WriteLine("You got the oatmeal cookie.");
        gameOver = true;
    }
    
    
}

public class OatmealException : Exception
{
    public OatmealException() {
    }

    public OatmealException(string message) : base(message) {
    }
}

//Answer this question:
//Did you make a custom exception type or use an existing one, and why did you choose what you did?
// I made a custom one, solely for practice.

//Answer this question:
// You could write this program without exceptions, but the requirements demanded an exception for learning purposes.
// If you didn’t have that requirement, would you have used an exception? Why or why not?
// No, the code could've handled itself fine.