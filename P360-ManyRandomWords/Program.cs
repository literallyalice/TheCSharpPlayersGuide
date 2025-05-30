using System.Text;

var input = "";
    
while (input != "q")
{
    Console.WriteLine("Enter a word: ");
    Console.Write("> ");
    input = Console.ReadLine()!.ToLower();
    if (input == "q") break;

    _ = HandleWord(input);

}

return;

async Task HandleWord(string word)
{
    var timeBefore = DateTime.Now;
    var tries = await RandomlyRecreateAsync(word);
    var timeAfter = DateTime.Now - timeBefore;
    
    Console.WriteLine($"The word {word} took {tries} attempts and {timeAfter.TotalSeconds}s.");
}

int RandomlyRecreate(string word)
{
    StringBuilder randomWord = new(word.Length);

    var tries = 0;
    while (randomWord.ToString() != word)
    {
        randomWord.Clear();
        for (var i = 0; i < randomWord.Capacity; i++)
        {
            randomWord.Append((char)('a' + Random.Shared.Next(26)));
        }
        tries++;
    }
    return tries;
}

Task<int> RandomlyRecreateAsync(string word)
{
    return Task.Run(() => RandomlyRecreate(word));
}