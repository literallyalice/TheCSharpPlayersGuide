Console.WriteLine("> Please provide us with a 5 digit password for your new door.");
Console.Write("> ");
string password = ValidateInput(InputType.Password);
Door door = new Door(password);

 
while (true) {
    Console.WriteLine($"The door is {door.Status.ToString().ToLower()}.");
    Console.Write(">");
    string input = ValidateInput(InputType.Command);
 
    switch (input.ToLower()) {
        case "open":
            door.Open();
            break;
        
        case "close":
            door.Close();
            break;
        
        case "lock":
            door.Lock();
            break;
        
        case "unlock":
            Console.Write("> Enter key: ");
            door.Unlock(ValidateInput(InputType.Password));
            break;
        
        case "reset":
            Console.Write("> Enter old key: ");
            string oldKey = ValidateInput(InputType.Password);
            if (!door.CheckPassword(oldKey)) {
                Console.WriteLine($"Wrong key. The door is currently {door.Status.ToString().ToLower()}.");
                break;
            }
            
            string newKey = ValidateInput(InputType.Password);
            door.Reset(oldKey, newKey);
            break;
        
        default:
            Console.WriteLine("That's not a command.");
            break;
            
    }
}
string ValidateInput(InputType inputType) {
    string? input = Console.ReadLine();
    while (input == null) {
        Console.WriteLine("> Invalid input, try again.");
        Console.Write("> ");
        input = Console.ReadLine();
    }
    
    if (inputType == InputType.Password) {
        while (!int.TryParse(input, out int num) || num.ToString().Length != 5) {
            Console.WriteLine("> Invalid input, try again. Must be exactly five digits.");
            Console.Write("> ");
            input = Console.ReadLine();
        }
    }
 
    string validatedInput = input;
    return validatedInput;
 
 
}
class Door
{
    public DoorStatus Status { get; private set; }
    private string key;
 
    public Door(string key) {
        Status = DoorStatus.Locked;
        this.key = key;
    }
 
    public void Open() {
        if (Status == DoorStatus.Closed) Status = DoorStatus.Open;
    }
 
    public void Close() {
        if (Status == DoorStatus.Open) Status = DoorStatus.Closed;
        }
 
    public void Unlock(string keyInput) {
        if (key == keyInput && Status == DoorStatus.Locked) Status = DoorStatus.Closed;
    }
 
    public void Lock() {
        if (Status == DoorStatus.Closed) Status = DoorStatus.Locked;
    }
 
    public void Reset(string oldKey, string newKey) {
        if (oldKey == key) key = newKey;
    }
 
    public bool CheckPassword(string key) {
        return this.key == key;
    }
    
}
 
enum InputType
{
    Command,
    Password
}
 
enum DoorStatus
{
    Locked,
    Closed,
    Open
}