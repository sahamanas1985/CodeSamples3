
using System.Diagnostics;

namespace AsyncTest
{
    public class ConcurrentWay
    {
        // Concurrent Way can start all tasks parallely.        

        public static async Task MakeBreakfast()
        {
            Console.WriteLine("Making Breakfast Concurrent way");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            Task coffeeTask = MakeCoffeeAsync();

            Task breadTask = ToastBreadAsync();
            Task jamTask = ApplyJamToBreadAsync();

            Task heatPanTask = HeatPanAsync();
            Task fryEggsTask = FryEggsAsync();
            Task fryBaconTask = FryBaconAsync();

            Task juiceTask = PourJuiceAsync();

            await Task.WhenAll(coffeeTask, breadTask, jamTask, heatPanTask, fryEggsTask, fryBaconTask, juiceTask);

            await coffeeTask;

            await breadTask;
            await jamTask;

            await heatPanTask;
            await fryEggsTask;
            await fryBaconTask;

            await juiceTask;

            sw.Stop();
            Console.WriteLine("Concurrent Way - Total Time Taken " + sw.ElapsedMilliseconds / 1000 + " Seconds");
        }


        public static async Task MakeCoffeeAsync()
        {
            Console.WriteLine("Making Coffee");
            await Task.Delay(3000);
            Console.WriteLine("Done - Making Coffee");
        }

        public static async Task ToastBreadAsync()
        {
            Console.WriteLine("Making Toast");
            await Task.Delay(2000);
            Console.WriteLine("Done - Making Toast");
        }

        public static async Task ApplyJamToBreadAsync()
        {
            Console.WriteLine("Applying Jam");
            await Task.Delay(1000);
            Console.WriteLine("Done - Applying Jam");
        }

        public static async Task HeatPanAsync()
        {
            Console.WriteLine("Heating Pan");
            await Task.Delay(3000);
            Console.WriteLine("Done - Heating Pan");
        }

        public static async Task FryEggsAsync()
        {
            Console.WriteLine("Frying Egg");
            await Task.Delay(5000);
            Console.WriteLine("Done - Frying Egg");
        }

        public static async Task FryBaconAsync()
        {
            Console.WriteLine("Frying Bacon");
            await Task.Delay(5000);
            Console.WriteLine("Done - Frying Bacon");
        }

        public static async Task PourJuiceAsync()
        {
            Console.WriteLine("Pouring Juice");
            await Task.Delay(1000);
            Console.WriteLine("Done - Pouring Juice");
        }
    }

}
