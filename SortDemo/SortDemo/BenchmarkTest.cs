using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortDemo
{
    public class BenchmarkTest
    {
        static int[] arr = new int[] { 2, 2, 4, 5, 2, 3, 3, 4, 4, 5 };

        [Benchmark]
        public void GetDistinctNumsByLinq()
        {
            int[] uniqueNums = arr.Distinct().ToArray();
            Console.WriteLine("Distinct Numbers " + string.Join(',', uniqueNums));
        }


        [Benchmark]
        public void GetDistinctNumsByHashSet()
        {
            int[] uniqueNums = new HashSet<int>(arr).ToArray();
            Console.WriteLine("Distinct Numbers " + string.Join(',', uniqueNums));
        }

    }
}
