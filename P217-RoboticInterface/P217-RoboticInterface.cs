Robot robot = new Robot();
Console.WriteLine("Enter three commands for the robot: ");
Console.WriteLine();

for (int i = 0; i < robot.Commands.Length; i++) {
    Console.Write("> ");
    var input = Console.ReadLine();
    IRobotCommand command = input switch {
        "on" => new OnCommand(),
        "off" => new OffCommand(),
        "north" => new NorthCommand(),
        "south" => new SouthCommand(),
        "east" => new EastCommand(),
        "west" => new WestCommand(),
        _ => throw new ArgumentOutOfRangeException()
    };
    robot.Commands[i] = command;
}

robot.Run();



public class Robot
{
    public int X { get; set; } 
    public int Y { get; set; } 
    public bool IsPowered { get; set; } 
    public IRobotCommand?[] Commands { get; } = new IRobotCommand?[3]; 
    public void Run() { 
        foreach (IRobotCommand? command in Commands) { 
            command?.Run(this); 
            Console.WriteLine($"[{X},{Y}] {IsPowered}"); 
        } 
    }
}

public interface IRobotCommand
{ 
    void Run(Robot robot);
}

public class OnCommand : IRobotCommand
{
    public void Run(Robot robot) {
        robot.IsPowered = true;
    }
}

public class OffCommand : IRobotCommand
{
    public void Run(Robot robot) {
        robot.IsPowered = false;
    }
}

public class NorthCommand : IRobotCommand
{
    public void Run(Robot robot) {
        if (!robot.IsPowered) return;
        robot.Y++;
    }
}

public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot) {
        if (!robot.IsPowered) return;
        robot.Y--;
    }
}

public class WestCommand : IRobotCommand
{
    public void Run(Robot robot) {
        if (!robot.IsPowered) return;
        robot.X--;
    }
}

public class EastCommand : IRobotCommand
{
    public void Run(Robot robot) {
        if (!robot.IsPowered) return;
        robot.X++;
    }
}