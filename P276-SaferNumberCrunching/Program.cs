int number;

do {
    Console.Write("Enter an integer: ");
}
while (int.TryParse(Console.ReadLine(), out number));
Console.WriteLine(number);

double number2;
do {
    Console.Write("Enter a double: ");
}
while (double.TryParse(Console.ReadLine(), out number2));
Console.WriteLine(number2);

bool truth;
do {
    Console.WriteLine("Enter true or false: ");
}
while (bool.TryParse(Console.ReadLine(),out truth));
Console.WriteLine(truth);