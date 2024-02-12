namespace P242_TheFountainOfObjects;

public class Room
{
    public string Title { get; set; }
    public string RoomMessage { get; set; }
    public string SenseMessage { get; init; }

    public List<Monster> Monsters { get; } = new List<Monster>();
    public ConsoleColor Color { get; init; }
    
    public bool CanBeSensed()  => SenseMessage != "" || Monsters.Count > 0;
    
    
    public Room() {
        Title = "A Room";
        RoomMessage = "You look around but find nothing special.";
        SenseMessage = "";
        Color = ConsoleColor.Gray;
    }
    
    // If one would want to create a custom empty room.
    public Room(string title, string message) {
        Title = title;
        RoomMessage = message;
        SenseMessage = "";
        Color = ConsoleColor.Gray;
    }
    
    public void Messages(Game game) {
        PostRoomMessage(game);
        PostSenseMessage(game);
    }

    protected virtual void PostRoomMessage(Game game) {
        ConsoleHelper.WriteLine(RoomMessage, Color);
    }

    
    // I add each nearby room to a list and post its SenseMessage if it has one
    private void PostSenseMessage(Game game) {
        var location = game.Player.Location;
        var adjacentRooms = new List<Room?>()
        {
            game.Map.GetRoomAtLocation(new Location(location.Row - 1, location.Column - 1)),
            game.Map.GetRoomAtLocation(new Location(location.Row - 1, location.Column)),
            game.Map.GetRoomAtLocation(new Location(location.Row - 1, location.Column + 1)),
            game.Map.GetRoomAtLocation(new Location(location.Row, location.Column - 1)),
            game.Map.GetRoomAtLocation(new Location(location.Row, location.Column)),
            game.Map.GetRoomAtLocation(new Location(location.Row, location.Column + 1)),
            game.Map.GetRoomAtLocation(new Location(location.Row + 1, location.Column - 1)),
            game.Map.GetRoomAtLocation(new Location(location.Row + 1, location.Column)),
            game.Map.GetRoomAtLocation(new Location(location.Row + 1, location.Column + 1))
        };
        foreach (var room in adjacentRooms.OfType<Room>().Where(room => room.CanBeSensed())) {
            
            ConsoleHelper.WriteLine(room.SenseMessage, ConsoleColor.Magenta);
            
            // If the room has monsters, write monsters sensemessage
            if (room.Monsters.Count > 0) {
                foreach (var monster in room.Monsters) {
                    ConsoleHelper.WriteLine(monster.SenseMessage, ConsoleColor.DarkRed);
                }
            }
        }
    }
}

public class FountainRoom : Room
{
    public FountainRoom() {
        Title = "Fountain Room";
        RoomMessage = "You hear water dripping in this room. The Fountain of Objects is here!";
        SenseMessage = "";
        Color = ConsoleColor.DarkCyan;
    }

    protected override void PostRoomMessage(Game game) {
        if (game.IsFountainOn) {
            RoomMessage = "You hear the rushing waters from the Fountain of Objects. It has been reactivated!";
            ConsoleHelper.WriteLine(RoomMessage, Color);
        }
        else {
            RoomMessage = "You hear water dripping in this room. The Fountain of Objects is here!";
            ConsoleHelper.WriteLine(RoomMessage, Color);
        }
    }
}

public class EntranceRoom : Room
{
    public EntranceRoom() {
        Title = "Entrance Room";
        RoomMessage = "You see light coming from the cavern entrance.";
        SenseMessage = "";
        Color = ConsoleColor.Yellow;
    }

    protected override void PostRoomMessage(Game game) {
        ConsoleHelper.WriteLine(RoomMessage, Color);
    }
}

public class PitRoom : Room
{
    public string KillMessage { get; }
    public PitRoom() {
        Title = "Pit";
        RoomMessage = "This room kills you or something idk";
        SenseMessage = "There's a smelly pit nearby.";
        KillMessage = "You have fallen into a pit and died.";
        Color = ConsoleColor.DarkYellow;
    }

    protected override void PostRoomMessage(Game game) {
        ConsoleHelper.WriteLine(RoomMessage, ConsoleColor.Red);
    }
}