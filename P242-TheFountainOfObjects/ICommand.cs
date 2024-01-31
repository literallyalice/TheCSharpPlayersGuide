namespace P242_TheFountainOfObjects;

public interface ICommand
{
    void Execute(Game game);
}

public class MoveCommand : ICommand
{
    public Direction Direction { get; }

    public MoveCommand(Direction direction) {
        Direction = direction;
    }

    public void Execute(Game game) {
        Location currentLocation = game.Player.Location;
        Location newLocation = Direction switch
        {
            Direction.North => new Location(currentLocation.Row - 1, currentLocation.Column),
            Direction.South => new Location(currentLocation.Row + 1, currentLocation.Column),
            Direction.West => new Location(currentLocation.Row, currentLocation.Column - 1),
            Direction.East => new Location(currentLocation.Row, currentLocation.Column + 1),
            _ => throw new ArgumentOutOfRangeException()
        };
        
        if (game.Map.IsOnMap(newLocation)) {
            game.Player.Location = newLocation;
        }
        else {
            ConsoleHelper.WriteLine("There is a wall there.", ConsoleColor.Red);
        }
    }
}

public class EnableFountainCommand : ICommand
{
    public void Execute(Game game) {
        
        if(game.Map.GetRoomAtLocation(game.Player.Location) is FountainRoom) {
            game.IsFountainOn = true;
        }
        else {
            ConsoleHelper.WriteLine("The fountain is not in this room, there was no effect.", ConsoleColor.Red);
        }
    }
}