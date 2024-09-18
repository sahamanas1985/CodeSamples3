
int[] numbers = new int[] { 60, 25, 96, 79, 104, 4 };

int max = 0;

foreach (var number in numbers)
{
    if(number > max) max = number;
}


Console.WriteLine("Max number is: " + max);
