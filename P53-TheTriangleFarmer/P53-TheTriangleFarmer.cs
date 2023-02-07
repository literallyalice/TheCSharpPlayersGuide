float height;
float width;
float area;

Console.WriteLine("P-Thags' Area Calculator");

Console.Write("Enter height: ");
height = Convert.ToSingle(Console.ReadLine());

Console.Write("Enter width: ");
width = Convert.ToSingle(Console.ReadLine());

Console.WriteLine("---------");
area = (height + width) / 2;
Console.WriteLine("The area is " + area + " units^2.");
