Console.WriteLine("What kind of thing are we talking about?");
string a = Console.ReadLine(); // the thing being named
Console.WriteLine("How would you describe it? Big? Azure? Tattered?");
string b = Console.ReadLine(); // thing description
string c = " of Doom 3000"; // suffix of thing
Console.WriteLine("The " + b + " " + a + c + "!");


// Aside from comments, what else could you do to make this code more understandable?
// Merging string c & d cleans up the final WriteLine a lot