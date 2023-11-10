

Coordinate coord1 = new Coordinate(4, 3);
Coordinate coord2 = new Coordinate(5, 2);
Coordinate coord3 = new Coordinate(14, 12);

Console.WriteLine("Is coord1 adjacent to coord2?");
Console.WriteLine(coord1.IsAdjacent(coord2) ? "Yes" : "No");

Console.WriteLine("Is coord2 adjacent to coord3?");
Console.WriteLine(coord2.IsAdjacent(coord3) ? "Yes" : "No");
Console.ReadLine();


public readonly struct Coordinate
{
    public readonly int Row = 0;
    public readonly int Col = 0;

    public Coordinate(int row, int col)
    {
        Row = row;
        Col = col;
    }

    public bool IsAdjacent(Coordinate coordinate)
    {
        if (Row == coordinate.Row + 1 ||
            Row == coordinate.Row - 1 ||
            Col == coordinate.Col + 1 ||
            Col == coordinate.Col - 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}