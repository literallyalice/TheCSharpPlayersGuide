using System.ComponentModel;
using System.Reflection;

namespace P242_TheFountainOfObjects;

public record Commands
{
    public static List<Type> CommandList = new List<Type>
    {
        typeof(MoveCommand),
        typeof(ShootCommand),
        typeof(EnableFountainCommand),
        typeof(HelpCommand)
    };
}

public interface ICommand
{
    void Execute(Game game);
}

[Description("- move (direction): Moves the player in selected direction, \"move north\", \"move south\", \"move west\", \"move east\". ")]
public class MoveCommand : ICommand
{
    private Direction Direction { get; }
    

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

[Description("- enable fountain: Enables the fountain, must be in the fountain room for it to work.")]
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

[Description("- shoot (direction): Fires your bow in the selected direction, \"shoot north\", \"shoot south\",\"shoot west\", \"shoot east\".")]
public class ShootCommand : ICommand
{
    private Direction Direction { get; }

    public ShootCommand(Direction direction) {
        Direction = direction;
    }
    
    public void Execute(Game game) {
        if (game.Player.Arrows < 1) {
            ConsoleHelper.WriteLine("You're out of arrows.", ConsoleColor.Yellow);
            return;
        }
        var targetRoom = Direction switch
        {
            Direction.North => game.Player.Location with { Row = game.Player.Location.Row - 1 },
            Direction.South => game.Player.Location with { Row = game.Player.Location.Row + 1 },
            Direction.West => game.Player.Location with { Column = game.Player.Location.Column - 1 },
            Direction.East => game.Player.Location with { Column = game.Player.Location.Column + 1},
            _ => throw new ArgumentOutOfRangeException()
        };
        
        game.Player.Arrows--;
        Room? room = game.Map.GetRoomAtLocation(targetRoom);
        if (room is { Monsters.Count: > 0 }) {
            room.Monsters[0].MonsterDeath(game, targetRoom);
        }
        else {
            ConsoleHelper.WriteLine("There was nothing there, you just wasted an arrow.", ConsoleColor.Yellow);
        }
    }
}

[Description("- help: Lists available commands and their description.")]
public class HelpCommand : ICommand
{
    private readonly List<Type> _commandTypes;

    public HelpCommand(List<Type> commandTypes) {
        _commandTypes = commandTypes;
    }
    public void Execute(Game game) {
        foreach (var description in _commandTypes.Select(GetDescription)) {
            ConsoleHelper.WriteLine(description, ConsoleColor.Green);
        }
    }

    private string GetDescription(Type commandType) {
        var descriptionAttribute = commandType.GetCustomAttribute<DescriptionAttribute>();

        return descriptionAttribute != null ? descriptionAttribute.Description : "No description available.";
    }
}