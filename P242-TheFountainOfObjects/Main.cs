using P242_TheFountainOfObjects;

Game game = GamePresets.GameSetup();
game.Run();


public record Location(int Row, int Column);

public class Player
{
    public Location Location { get; set; }

    public bool IsAlive { get; set; } = true;

    public string CauseOfDeath { get; private set; } = "";
    
    public int Arrows { get; set; }
    
    public Player(Location start, int arrows) {
        Location = start;
        Arrows = arrows;
    }

    public void Kill(string cause) {
        IsAlive = false;
        CauseOfDeath = cause;
    }
    
}

public class Game
{
    public Map Map { get; }
    public Player Player { get; }
    public bool IsFountainOn { get; set; }

    
    public Game(Map map, Player player) {

        Player = player;
        Map = map;
    }

    public void Run() {
        WelcomeMessage();
        
        while (!HasWon && Player.IsAlive) {
            DisplayStatus();
            var command = GetCommand();
            command.Execute(this);

            if (CurrentRoom is PitRoom) {
                Player.Kill((CurrentRoom as PitRoom)!.KillMessage);
            }

            if (CurrentRoom.Monsters.Count > 0) {
                for (var i = CurrentRoom.Monsters.Count - 1; i >= 0; i--)
                {
                    CurrentRoom.Monsters[i].HandleInteraction(this);
                }
            }
        }

        if (HasWon) {
            ConsoleHelper.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life",
                ConsoleColor.DarkGreen);
            ConsoleHelper.WriteLine("You win!", ConsoleColor.DarkGreen);
        }
        else {
            ConsoleHelper.WriteLine(Player.CauseOfDeath, ConsoleColor.Red);
            ConsoleHelper.WriteLine("You lost.", ConsoleColor.Red);
        }
    }

    private void WelcomeMessage() {
        ConsoleHelper.WriteLine("You enter the Cavern of Objects, a maze of rooms filled with dangerous pits in search of the Fountain of Objects.", ConsoleColor.DarkMagenta);
        ConsoleHelper.WriteLine("Light is visible only in the entrance, and no other light is seen anywhere in the caverns.", ConsoleColor.DarkMagenta);
        ConsoleHelper.WriteLine("You must navigate the Caverns with your other senses.", ConsoleColor.DarkMagenta);
        ConsoleHelper.WriteLine("Find the Fountain of Objects, activate it, and return to the entrance.", ConsoleColor.DarkMagenta);
        ConsoleHelper.WriteLine("Look out for pits. You will smell something foul if a pit is in an adjacent room. If you enter a room with a pit, you will die.", ConsoleColor.DarkMagenta);
        ConsoleHelper.WriteLine("Maelstroms are violent forces of sentient wind. Entering a room with one could transport you to any other location in the caverns. You will be able to hear their growling and groaning in nearby rooms.", ConsoleColor.DarkMagenta);
        ConsoleHelper.WriteLine("You carry with you a bow and a quiver of arrows. You can use them to shoot monsters in the caverns but be warned: you have a limited supply.", ConsoleColor.DarkMagenta);
    }
    private void DisplayStatus() {
        ConsoleHelper.WriteLine("--------------------------------------------------------------", ConsoleColor.Gray);
        ConsoleHelper.WriteLine($"You are in the room at (Row:{Player.Location.Row}, Col:{Player.Location.Column}). | Arrows: {Player.Arrows} | 'help' for a list of commands",
            ConsoleColor.Gray);
        
        CurrentRoom.Messages(this);

        // sense handling? maybe let all the room variations have two methods,
        // one arrive text message and one sense message
        // if the room is sensed https://stackoverflow.com/questions/3007460/how-to-check-if-anonymous-object-has-a-method
    }

    private ICommand GetCommand() {
        while (true) {
            ConsoleHelper.Write("> ", ConsoleColor.White);
            Console.ForegroundColor = ConsoleColor.Cyan;
            var input = Console.ReadLine()?.ToLower();
            
            if (input is "move north" or "move up") return new MoveCommand(Direction.North);
            if (input is "move south" or "move down") return new MoveCommand(Direction.South);
            if (input is "move east" or "move right") return new MoveCommand(Direction.East);
            if (input is "move west" or "move left") return new MoveCommand(Direction.West);
            
            if (input is "enable fountain") return new EnableFountainCommand();
            
            if (input is "shoot north" or "shoot up") return new ShootCommand(Direction.North);
            if (input is "shoot south" or "shoot down") return new ShootCommand(Direction.South);
            if (input is "shoot east" or "shoot right") return new ShootCommand(Direction.East);
            if (input is "shoot west" or "shoot left") return new ShootCommand(Direction.West);

            if (input is "help") return new HelpCommand(CommandHelper.GetTypesImplementingInterface<ICommand>());


            ConsoleHelper.WriteLine(
                string.IsNullOrEmpty(input) ? "You have to write a command." : $"I did not understand '{input}'.",
                ConsoleColor.Red);
        }
    }


    public bool HasWon => CurrentRoom is EntranceRoom && IsFountainOn;

    public Room CurrentRoom => Map.GetRoomAtLocation(Player.Location)!;
}

public class Map
{
    public int Rows { get; }
    public int Columns { get; }
    public Room[,] Rooms { get; }
    
    public Map(int rows, int columns) {
        Rows = rows;
        Columns = columns;
        Rooms = new Room[rows, columns];
        
        // Initialize each room with EmptyRoom by default
        for (var i = 0; i < rows; i++) {
            for (var j = 0; j < columns; j++) {
                Rooms[i, j] = new Room();
            }
        }
    }

    public Room? GetRoomAtLocation(Location location) => IsOnMap(location) ? Rooms[location.Row, location.Column] : null;
    

    public void SetRoomAtLocation(Location location, Room room) => Rooms[location.Row, location.Column] = room;

    public void AddMonsterToLocation(Location location, Monster monster) =>
        Rooms[location.Row, location.Column].Monsters.Add(monster);

    public void RemoveMonsterFromLocation(Location location, Monster monster) =>
        Rooms[location.Row, location.Column].Monsters.Remove(monster);

    public void MoveMonster(Location oldLocation, Location newLocation, Monster monster) {
        AddMonsterToLocation(newLocation, monster);
        RemoveMonsterFromLocation(oldLocation, monster);
    }
    
    public bool IsOnMap(Location location) =>
        location.Row >= 0 &&
        location.Row < Rooms.GetLength(0) &&
        location.Column >= 0 &&
        location.Column < Rooms.GetLength(1);

}

public static class ConsoleHelper
{
    public static void WriteLine(string text, ConsoleColor color) {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
    }

    public static void Write(string text, ConsoleColor color) {
        Console.ForegroundColor = color;
        Console.Write(text);
    }
}



public enum MapSize { Small, Medium, Large }
public enum Direction {North, South, West, East }