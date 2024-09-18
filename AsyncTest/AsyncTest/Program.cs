
using AsyncTest;

NormalWay.MakeBreakfast();
Console.WriteLine("\n\n");

await AsyncWay.MakeBreakfast();
Console.WriteLine("\n\n");

await ConcurrentWay.MakeBreakfast();
Console.WriteLine("\n\n");

await DependantConcurrentWay.MakeBreakfast();
Console.WriteLine("\n\n");

await WithReturnTypeWay.StartMethods();



