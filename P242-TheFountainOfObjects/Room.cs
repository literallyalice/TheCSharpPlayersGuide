﻿namespace P242_TheFountainOfObjects;

public class Room
{
    public string Title { get; set; }
    public string RoomMessage { get; set; }
    
    public string SenseMessage { get; set; }
    public ConsoleColor Color { get; set; }
    
    
    public Room() {
        Title = "Empty Room";
        RoomMessage = "You look around but find nothing.";
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

    public virtual void PostRoomMessage(Game game) {
        ConsoleHelper.WriteLine(RoomMessage, Color);
    }

    
    // dude i dont even know what this implementation is
    // i thought it would be decent but at this point im lost
    // I add each nearby room to a list and post its SenseMessage if it has one
    public void PostSenseMessage(Game game) {
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
        foreach (var room in adjacentRooms.OfType<Room>().Where(room => room.HasSenseMessage())) {
            ConsoleHelper.WriteLine(room.SenseMessage, ConsoleColor.Magenta);
        }
    }
    
    // Returns true if provided location has a sense message
    bool HasSenseMessage() {
        return this.SenseMessage != "";
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

    public override void PostRoomMessage(Game game) {
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

    public override void PostRoomMessage(Game game) {
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

    public override void PostRoomMessage(Game game) {
        ConsoleHelper.WriteLine(RoomMessage, ConsoleColor.Red);
    }
}