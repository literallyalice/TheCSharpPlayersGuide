BlockCoordinate block1 = new BlockCoordinate(0, 0);
BlockOffset block2 = new BlockOffset(1, 1);
block1 += Direction.South;
block1 += block2;
Console.WriteLine($"{block1}");
Console.WriteLine($"{block1[0]}");
Console.WriteLine($"{block1[1]}");


public record BlockCoordinate(int Row, int Column)
{
    public static BlockCoordinate operator +(BlockCoordinate start, BlockOffset offset) 
        => new BlockCoordinate(start.Row + offset.RowOffset, start.Column + offset.ColumnOffset);

    public static BlockCoordinate operator +(BlockCoordinate start, Direction dir)
        => dir switch {
            Direction.North => new BlockCoordinate(start.Row - 1, start.Column),
            Direction.East => new BlockCoordinate(start.Row, start.Column + 1),
            Direction.South => new BlockCoordinate(start.Row + 1, start.Column),
            Direction.West => new BlockCoordinate(start.Row, start.Column - 1),
            _ => new BlockCoordinate(start.Row, start.Column)
        };

    public int this[int index] => index == 0 ? Row : Column;
};

public record BlockOffset(int RowOffset, int ColumnOffset);

public enum Direction
{
    North,
    East,
    South,
    West
};