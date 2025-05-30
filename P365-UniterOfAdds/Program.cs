Console.WriteLine(Add(1, 2));
Console.WriteLine(Add(1.02d, 1.03d));
Console.WriteLine(Add("Hi ", "Dad"));
var time = DateTime.Now;
Console.WriteLine(Add(time, DateTime.Now - time));
return;


static dynamic Add(dynamic a, dynamic b) => a + b;