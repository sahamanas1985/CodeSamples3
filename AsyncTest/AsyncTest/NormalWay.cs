
using System.Diagnostics;

namespace AsyncTest
{
    public class NormalWay
    {

        public static void MakeBreakfast()
        {
            Console.WriteLine("Making Breakfast normal way");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            Console.WriteLine(MakeCoffee());
            Console.WriteLine(ToastBread());
            Console.WriteLine(ApplyJamToBread());
            Console.WriteLine(HeatPan());
            Console.WriteLine(FryEggs());
            Console.WriteLine(FryBacon());
            Console.WriteLine(PourJuice());

            sw.Stop();
            Console.WriteLine("Normal Way - Total Time Taken " + sw.ElapsedMilliseconds / 1000 + " Seconds");
        }

        public static string MakeCoffee()
        {
            Thread.Sleep(3000);
            return("Coffee is Ready");
        }

        public static string ToastBread()
        {
            Thread.Sleep(2000);
            return("Bread is Toasted");
        }

        public static string ApplyJamToBread()
        {
            Thread.Sleep(1000);
            return("Jam added to Bread");
        }

        public static string HeatPan()
        {
            Thread.Sleep(3000);
            return("Pan is now Hot");
        }

        public static string FryEggs()
        {
            Thread.Sleep(5000);
            return("Egg Fried");
        }

        public static string FryBacon()
        {
            Thread.Sleep(5000);
            return("Bacon fried");
        }

        public static string PourJuice()
        {
            Thread.Sleep(1000);
            return("Juice poured");
        }
    }
}
