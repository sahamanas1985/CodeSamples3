namespace XunitDemo;

class Program
{
    static void Main(string[] args)
    {
        MyCalc calc = new MyCalc(4, 5);

        Console.WriteLine("Sum " + calc.sum(7, 3));
        Console.WriteLine("Multiply " + calc.multi());

    }
}