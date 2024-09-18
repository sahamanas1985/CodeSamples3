using SortDemo;

using BenchmarkDotNet.Running;

//int[] arr = new int[] { 2, 2, 4, 5, 2, 3, 3, 4, 4, 5 };

//Console.WriteLine("Original array " + string.Join(',', arr));


BenchmarkRunner.Run<BenchmarkTest>();


//int[] myarray = arrstring.Split(',').Select(int.Parse).ToArray();


/*
var groupbyint = arr.GroupBy(x => x).Select(g => new {Num = g.Key, Count = g.Count()});

foreach(var item in groupbyint)
{
    Console.WriteLine("Number : " + item.Num + "  Count : " + item.Count);
}


// int[] uniqueNums = arr.Distinct().ToArray();


int[] uniqueNums = new HashSet<int>(arr).ToArray();

Console.WriteLine("Distinct Numbers " + string.Join(',', uniqueNums));

foreach (int i in uniqueNums)
{
    Console.WriteLine("Num: " + i + " Count: " + arr.Where(j => j == i).Count());
}

string line = "this is a text";
char[] arrChar = line.Replace(" ","").ToCharArray();


arrChar.GetArrayCounts();

// Console.WriteLine("Character array " + string.Join(',', uniqueChars));

*/








