using System.Text;
Console.WriteLine("Enter a word: ");
Console.Write("> ");

var input = Console.ReadLine()!.ToLower();
var timeBefore = DateTime.Now;
Console.WriteLine(await RandomlyRecreateAsync(input));
var timeSpent = DateTime.Now - timeBefore;
Console.WriteLine(
    $"{timeSpent.Hours}h, {timeSpent.Minutes}m, {timeSpent.Seconds}s, {timeSpent.Milliseconds}ms, {timeSpent.Microseconds}μs");
return;

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