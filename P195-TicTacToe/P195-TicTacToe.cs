
GameManager game = new GameManager();


// Collaborators: PlayerInterface
public class GameManager
{
    public bool XTurn { get; set; }
    public int[] Board { get; set; }
    public PlayerInterface Interface;
    

    public GameManager() {
        XTurn = true;
        Board = new int[9];
        Array.Clear(Board, 0, Board.Length);

        Interface = new PlayerInterface();
    }

    public void StartGame() {
        Interface.RenderBoard(Board, XTurn);
    }
    
    
}

// Collaborators: GameManager
public class PlayerInterface
{
    public void RenderBoard(int[] board, bool xTurn) {
        Console.WriteLine(xTurn ? "It's X's Turn." : "It's O's turn.");
        Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
        Console.WriteLine("Select square with ");
    }
}