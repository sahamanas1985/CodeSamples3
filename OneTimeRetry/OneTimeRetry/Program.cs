
Console.WriteLine("Hello, World!");


int Sum(int x, int y)
{
    return x + y;
}

string TextCheck(string input)
{
    return "You entered " + input;
}



T Retry<T>(Func<T> func)
{
    try { return func(); }
    catch { return func(); }
}
