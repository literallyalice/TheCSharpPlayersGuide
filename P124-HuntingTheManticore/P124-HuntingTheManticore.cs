int manticoreHealth = 10;
int cityHealth = 15;
int round = 1;

int manticoreDistance = -1;
int targetRange = -1;
int upperCannonRange = 100;
int lowerCannonRange = 0;


manticoreDistance = GetNumberWithinRange(
    "Player 1, how far away do you want to station the Manticore?",
    lowerCannonRange, upperCannonRange);

while (manticoreHealth > 0 && cityHealth > 0) {
    Console.WriteLine("--------------------");
    Console.WriteLine($"Round: {round} | City: {cityHealth} | Manticore: {manticoreHealth}");
    Console.WriteLine($"The city cannon will deal {CannonDamage()} damage this round");

    targetRange = (GetNumberWithinRange(
        "Enter cannon range: ", lowerCannonRange, upperCannonRange));
    
    if (targetRange == manticoreDistance) {
        Console.WriteLine("That round was a DIRECT HIT.");
        manticoreHealth -= CannonDamage();
    }
    else if (targetRange > manticoreDistance) Console.WriteLine("That round OVERSHOT the target.");
    else if (targetRange < manticoreDistance) Console.WriteLine("That round FELL SHORT of the target.");

    if (manticoreHealth > 0) {
        Console.WriteLine("The Manticore deals 1 damage to the city.");
        cityHealth--;
    }
    
    round++;
}

Console.WriteLine("--------------------");
if (manticoreHealth > 0) {
    Console.WriteLine("The Manticore has won the battle. The City of Consolas lay in ruin.");
}
else {
    Console.WriteLine("The Manticore has been destroyed. The City of Consolas has been saved.");
}




int GetNumberWithinRange(string prompt, int lowerBound, int upperBound) {
    var number = -1;
    while (number > upperBound || number < lowerBound) {
        Console.WriteLine(prompt);
        Console.Write("> ");
        number = Convert.ToInt32(Console.ReadLine());
        if (number > upperBound || number < lowerBound) {
            Console.WriteLine($"You must enter a number between {lowerBound} and {upperBound}.");
        }
    }
    return number;
}

int CannonDamage() {
    if (round % 5 == 0 && round % 3 == 0) return 10; 
    if (round % 5 == 0) return 5; 
    if (round % 3 == 0) return 3;
    else return 1;
}
