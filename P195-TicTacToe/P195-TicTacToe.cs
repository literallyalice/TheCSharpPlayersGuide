
GameManager game = new GameManager();
game.StartGame();


// Collaborators: PlayerInterface
public class GameManager
{
    public bool XTurn { get; set; }
    public string[] Board { get; set; }
    public PlayerInterface Interface;
    
    

    public GameManager() {
        XTurn = true;
        Board = new string[9];
        Array.Fill(Board, " ");

        Interface = new PlayerInterface();
    }

    public void StartGame() {
        var gameOver = false;
        while (!gameOver) {
            
            Console.Clear();
            Interface.RenderBoard(Board, XTurn);
            var playerInput = Interface.Input(Board);
            
            Board[playerInput - 1] = XTurn ? "X" : "O";
            
            if (CheckForWin()) {
                Console.Clear();
                Interface.RenderBoard(Board, XTurn);
                Console.WriteLine($"Congratulations! {(XTurn ? "X" : "O")} has won.");
                gameOver = true;
                Console.ReadLine();
                continue;
            }
            
            gameOver = !Board.Contains(" "); // sets gameOver to false if a 0 is found in Board
            if (gameOver) {
                Console.Clear();
                Interface.RenderBoard(Board, XTurn);
                Console.WriteLine("The game has concluded in a draw.");
                Console.ReadLine();
            }
            
            XTurn = !XTurn;



        }
    }
    

    private bool CheckForWin() {
        var value = XTurn ? "X" : "O";

        // check columns
        if (AreAllElementsIdentical(new[] { 0, 1, 2 })) return true;
        if (AreAllElementsIdentical(new[] { 3, 4, 5 })) return true;
        if (AreAllElementsIdentical(new[] { 6, 7, 8 })) return true;

        // check rows
        if (AreAllElementsIdentical(new[] { 6, 3, 0 })) return true;
        if (AreAllElementsIdentical(new[] { 7, 4, 1 })) return true;
        if (AreAllElementsIdentical(new[] { 8, 5, 2 })) return true;

        // check diagonals
        if (AreAllElementsIdentical(new[] { 6, 4, 2 })) return true;
        if (AreAllElementsIdentical(new[] { 8, 4, 0 })) return true;

        return false;

        bool AreAllElementsIdentical(IEnumerable<int> indices) => indices.All(index => Board[index] == value);
    }


}

// Collaborators: GameManager
public class PlayerInterface
{
    public void RenderBoard(string[] board, bool xTurn) {
        Console.WriteLine(xTurn ? "It's X's Turn." : "It's O's turn.");
        Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
    }

    public int Input(string[] board) {
        while(true){
            Console.WriteLine("Enter a square position using your numpad: ");
            Console.Write(">");
            var input = Console.ReadLine();
            
            var result = int.TryParse(input, out var number);
            if (!result) continue;
            if (board[number - 1] is "X" or "O") {
                Console.WriteLine("That square is already occupied.");
                continue;
            }
            
            if (number is >= 1 and <= 9) {
                return number;
            }
        }
        
    }
}