

namespace FractionAdd
{
    internal class Fraction
    {
        public int num { get; set; }
        public int denom { get; set; }

        public Fraction(int Num, int Denom)
        {
            num = Num;
            denom = Denom;
        }

        public static Fraction FractionAdd(Fraction Fra1, Fraction Fra2)
        {
      
            int MultiplyDenoms = Fra1.denom * Fra2.denom;
            int Sum = Fra1.num * Fra2.denom + Fra2.num * Fra1.denom;
            Fraction Fra3 = new Fraction(Sum, MultiplyDenoms);
            return Simplify(Fra3);
        }

        public static Fraction Simplify(Fraction Fra)
        {
            int smallerNumber = Fra.num < Fra.denom ? Fra.num : Fra.denom;            
            
            int divisor = 1;

            for (int i= smallerNumber; i >= 1; i--)
            {                
                if(Fra.num % i == 0 && Fra.denom % i == 0)
                {
                    divisor = i;
                    break;
                }
            }

            Fraction simplFrac = new Fraction(Fra.num/divisor, Fra.denom / divisor);
            return simplFrac;
        }
    }

    
}
