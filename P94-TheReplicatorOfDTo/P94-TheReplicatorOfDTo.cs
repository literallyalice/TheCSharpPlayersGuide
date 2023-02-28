Console.WriteLine("The Replicator Of D'To");
var startingNumbers = new int[5];

Console.WriteLine("Fill the array!");
for (var i = 0; i < startingNumbers.Length; i++) {
    Console.Write($"{i + 1}. ");
    startingNumbers[i] = Convert.ToInt32(Console.ReadLine());
}

var newNumbers = new int[5];
for (var i = 0; i < startingNumbers.Length; i++) {
    newNumbers[i] = startingNumbers[i];
}

for (var i = 0; i < startingNumbers.Length; i++) {
    Console.Write($"{i+1}. First Array: {startingNumbers[i]} | ");
    Console.WriteLine($"Second Array: {newNumbers[i]}");
}
