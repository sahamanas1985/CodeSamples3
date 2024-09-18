
using System.Diagnostics;

namespace AsyncTest
{
    public class AsyncWay
    {
        // Async Way will still take same time as normal way. But the threads will not be blocked.
        // The Threads can respond to other tasks such as UI intercation when they are waiting.

        public static async Task MakeBreakfast()
        {
            Console.WriteLine("Making Breakfast async way");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            Console.WriteLine(await MakeCoffeeAsync());
            Console.WriteLine(await ToastBreadAsync());
            Console.WriteLine(await ApplyJamToBreadAsync());
            Console.WriteLine(await HeatPanAsync());
            Console.WriteLine(await FryEggsAsync());
            Console.WriteLine(await FryBaconAsync());
            Console.WriteLine(await PourJuiceAsync());

            sw.Stop();
            Console.WriteLine("Async Way - Total Time Taken " + sw.ElapsedMilliseconds / 1000 + " Seconds");
        }


        public static async Task<string> MakeCoffeeAsync()
        {
            await Task.Delay(3000);
            return("Coffee is Ready");           
        }

        public static async Task<string> ToastBreadAsync()
        {
            await Task.Delay(2000);
            return ("Bread is Toasted");
        }

        public static async Task<string> ApplyJamToBreadAsync()
        {
            await Task.Delay(1000);
            return ("Jam added to Bread");
        }

        public static async Task<string> HeatPanAsync()
        {
            await Task.Delay(3000);
            return ("Pan is now Hot");
        }

        public static async Task<string> FryEggsAsync()
        {
            await Task.Delay(5000);
            return ("Egg Fried");
        }

        public static async Task<string> FryBaconAsync()
        {
            await Task.Delay(5000);
            return ("Bacon fried");
        }

        public static async Task<string> PourJuiceAsync()
        {
            await Task.Delay(1000);
            return ("Juice poured");
        }
    }

}
