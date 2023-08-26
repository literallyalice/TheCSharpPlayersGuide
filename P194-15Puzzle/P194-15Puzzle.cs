Console.WriteLine("Hi!");

/*

GameManager:
Collaborators: Board, Player
* Tracks how many moves the player has made
* Checks for win condition (if the list is sorted)


Board:
Collaborators:
* Holds the board state in a list, the empty spot would be represented by a 0
* Constructor that lets us generate a random board
* method(s) to move a number in a direction on the board if its a valid move
* method to check if move is valid( a move is valid if its the index of 0 +/- 1 or 4(board width)

Player:
Collaborators: Console, Board
* Takes input from user
* Tells player they won and how many moves it takes
* Display round count
* display state of the board







*/