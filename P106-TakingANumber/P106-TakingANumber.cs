






int AskForNumber(string text) {
    Console.WriteLine(text);
    Console.Write("> ");
    var response = Convert.ToInt32(Console.ReadLine());
    return response;
}

int AskForNumbersInRange(string text, int min, int max) {
    Console.WriteLine(text);
    var response = Int32.MaxValue;
    while (response ! > min && response ! < max) {
        Console.Write("> ");
        response = Convert.ToInt32(Console.ReadLine());
    }

    return response;
}