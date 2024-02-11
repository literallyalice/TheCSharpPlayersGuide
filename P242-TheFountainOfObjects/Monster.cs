namespace P242_TheFountainOfObjects;

public abstract class Monster
{
    public string Name { get; init; } = "Uninitiated Monster";
    public string SenseMessage { get; init; } = "Uninitiated SenseMessage";

    public abstract void HandleInteraction(Game game);
}

public class Maelstrom : Monster
{
    public Maelstrom() {
        Name = "Maelstrom";
        SenseMessage = $"You hear the growling and groaning of a {Name} nearby.";
    }

    
    
    public override void HandleInteraction(Game game) {
        // here the monster class is responsible for moving the player, which isn't a good idea
        //saving old location before its changed by the maelstrom
        var oldLocation = game.Player.Location;
        
        game.Player.Location = new Location(
            Math.Clamp(game.Player.Location.Row - 1, 0, game.Map.Rows - 1),
            Math.Clamp(game.Player.Location.Column + 2, 0, game.Map.Columns - 1));
        ConsoleHelper.WriteLine($"You have been moved by a {Name}, ", ConsoleColor.Yellow);
        
        game.Map.MoveMonster(
            oldLocation, 
            new Location(
                Math.Clamp(oldLocation.Row + 1, 0, game.Map.Rows - 1),
                Math.Clamp(oldLocation.Column - 2, 0, game.Map.Columns - 1)),
            this);
        ConsoleHelper.WriteLine($"The {Name} moved too.", ConsoleColor.Yellow);
        
        

    }
}

public class Amarok : Monster
{
    private string KillMessage { get; }
    
    public Amarok() {
        Name = "Amarok";
        SenseMessage = $"You can smell the rotten stench of an {Name} nearby.";
        KillMessage = $"You have been torn to shreds by an {Name}.";
    }

    public override void HandleInteraction(Game game) {
        game.Player.Kill(KillMessage);
    }
}
