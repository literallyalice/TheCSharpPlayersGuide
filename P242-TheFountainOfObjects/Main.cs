using P242_TheFountainOfObjects;

Game game = GamePresets.GameSetup();
game.Run();


public record Location(int Row, int Column);

public class Player
{
    public Location Location { get; set; }

    public bool IsAlive { get; set; } = true;

    public string CauseOfDeath { get; private set; } = "";
    
    public Player(Location start) {
        Location = start;
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
        
        while (!HasWon && Player.IsAlive) {
            DisplayStatus();
            var command = GetCommand();
            command.Execute(this);

            if (CurrentRoom is PitRoom) {
                Player.Kill((CurrentRoom as PitRoom)!.KillMessage);
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

    private void DisplayStatus() {
        ConsoleHelper.WriteLine("--------------------------------------------------------------", ConsoleColor.Gray);
        ConsoleHelper.WriteLine($"You are in the room at (Row:{Player.Location.Row}, Col:{Player.Location.Column}).",
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
            string? input = Console.ReadLine();

            switch (input) {
                case "move north":
                case "move up":
                    return new MoveCommand(Direction.North);
                
                case "move south":
                case "move down":
                    return new MoveCommand(Direction.South);
                
                case "move west":
                case "move left":
                    return new MoveCommand(Direction.West);
                
                case "move east":
                case "move right":
                    return new MoveCommand(Direction.East);
                
                case "enable fountain":
                    return new EnableFountainCommand();
                
                default:
                    ConsoleHelper.WriteLine($"I did not understand '{input}'.", ConsoleColor.Red);
                    break;
            }
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