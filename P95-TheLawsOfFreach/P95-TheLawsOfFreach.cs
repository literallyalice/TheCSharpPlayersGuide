var array = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };

var currentSmallest = int.MaxValue;
foreach (var t in array) {
    currentSmallest = t;
}
Console.WriteLine(currentSmallest);

var total = array.Sum();

var average = (float)total / array.Length;
Console.WriteLine(average);