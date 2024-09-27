//BlockCoordinate block1 = new BlockCoordinate(0, 0);
BlockOffset block2 = Direction.South;
Console.WriteLine(block2);



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

public record BlockOffset(int RowOffset, int ColumnOffset)
{
    public static implicit operator BlockOffset(Direction dir)
        => dir switch {
            Direction.North => new BlockOffset(-1, 0),
            Direction.South => new BlockOffset(1, 0),
            Direction.East => new BlockOffset(0, 1),
            Direction.West => new BlockOffset(0, -1),
            _ => new BlockOffset(0,0)
        };
}

public enum Direction
{
    North,
    East,
    South,
    West
};