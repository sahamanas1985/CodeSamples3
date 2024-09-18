using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XunitDemo
{
    public class MyCalc
    {
        public int Num1 { get; set; }
        public int Num2 { get; set; }

       
        public MyCalc(int num1, int num2)
        {
            Num1 = num1;
            Num2 = num2;
        }

        public int sum(int num1, int num2)
        {            
            return (num1 + num2);
        }

        public int multi()
        {
            return (Num1 * Num2);
        }


    }
}
