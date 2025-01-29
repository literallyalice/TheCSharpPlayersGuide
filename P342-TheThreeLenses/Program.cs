int[] numbers = { 1, 9, 2, 8, 3, 7, 4, 6, 5 };


IEnumerable<int> ProceduralQuery(int [] data){
    List<int> result = new List<int>();

    foreach (var d in data){
        if (d % 2 == 0){
            result.Add(d * 2);
        }
    }
    result.Sort();
    return result;
}

IEnumerable<int> KeywordQuery(int[] data){
    var result = from d in data
                 where d % 2 == 0
                 orderby d
                 select d * 2;
    
    return result;
}

IEnumerable<int> MethodQuery(int[] data) => data.Where(d => d % 2 == 0).Order().Select(d => d * 2);

Console.WriteLine(string.Join(", ", ProceduralQuery(numbers)));
Console.WriteLine(string.Join(", ", KeywordQuery(numbers)));
Console.WriteLine(string.Join(", ", MethodQuery(numbers)));
