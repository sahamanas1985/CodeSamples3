
using System.Diagnostics;

namespace AsyncTest
{
    public class WithReturnTypeWay
    {
        // Concurrent Way can start all tasks parallely.        

        public static async Task StartMethods()
        {
            Console.WriteLine("Execution Started");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            Task<string> A1Task = MethodA1();
            Task<string> B1Task = MethodB1();
            Task<string> C1Task = MethodC1();

            Task<string> B2Task = MethodB2(B1Task.Result);            
            Task<string> C2Task = MethodC2(A1Task.Result, B2Task.Result);

            await Task.WhenAll(C2Task);

            sw.Stop();
            Console.WriteLine("Concurrent Way - Total Time Taken " + sw.ElapsedMilliseconds / 1000 + " Seconds");
        }


        public static async Task<string> MethodA1()
        {
            Console.WriteLine("Method A1 - Started");
            await Task.Delay(3000);
            Console.WriteLine("Method A1 - Ended");
            return "Output - A1";
        }

        public static async Task<string> MethodB1()
        {
            Console.WriteLine("Method B1 - Started");
            await Task.Delay(2000);
            Console.WriteLine("Method B1 - Ended");
            return "Output_B1";
        }

        public static async Task<string> MethodB2(string B1Output)
        {
            Console.WriteLine("Method B2 - Started with Param " + B1Output);
            await Task.Delay(1500);
            Console.WriteLine("Method B2 - Ended");
            return "Output_B2";
        }

        public static async Task<string> MethodC1()
        {
            Console.WriteLine("Method C1 - Started");
            await Task.Delay(2500);
            Console.WriteLine("Method C1 - Ended");
            return "Output_C1";
        }

        public static async Task<string> MethodC2(string A1Output, string B2Output)
        {
            Console.WriteLine("Method C1 - Started with Param " + A1Output + ", " + B2Output);
            await Task.Delay(3000);
            Console.WriteLine("Method C1 - Ended");
            return "Output_C1";
        }

    }

}
