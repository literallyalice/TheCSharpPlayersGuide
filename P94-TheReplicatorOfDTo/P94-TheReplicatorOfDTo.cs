var numbers = new int[5];

Console.WriteLine("Fill the array!");
for (var i = 0; i < numbers.Length; i++) {
    Console.Write($"{i + 1}. ");
    numbers[i] = Convert.ToInt32(Console.ReadLine());
}

var newNumbers = new int[5];
for (var i = 0; i < numbers.Length; i++) {
    newNumbers[i] = numbers[i];
}

for (var i = 0; i < numbers.Length; i++) {
    Console.Write($"{i+1}. First Array: {numbers[i]} | ");
    Console.WriteLine($"Second Array: {newNumbers[i]}");
}
