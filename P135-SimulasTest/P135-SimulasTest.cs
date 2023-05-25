ChestState currentChestState = ChestState.Locked;

Console.WriteLine("Simula's Test");
Console.WriteLine("Commands: Open, Close, Lock, Unlock.");
Console.WriteLine("------------------------------------");
while (true) {
    Console.WriteLine($"The chest is {currentChestState.ToString().ToLower()}. What do you want to do?");
    Console.Write("> ");
    var input = Console.ReadLine()?.ToLower();
    switch (currentChestState) {
        
        case ChestState.Open:
            if (input == "close") currentChestState++;
            break;
        
        case ChestState.Locked:
            if (input == "unlock") currentChestState--;
            break;
        
        case ChestState.Closed:
            if (input == "open") currentChestState--;
            else if (input == "lock") currentChestState++;
            break;
        
        default:
            break;
    }
}


enum ChestState
{
    Open = 0,
    Closed = 1,
    Locked = 2
}