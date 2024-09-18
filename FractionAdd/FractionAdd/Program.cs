
using FractionAdd;

Fraction Fra1 = new Fraction(5, 12);
Fraction Fra2 = new Fraction(1, 20);

Fraction FraAdd = Fraction.FractionAdd(Fra1, Fra2);

Console.WriteLine("Add complete. Fraction is: " + FraAdd.num + "/" + FraAdd.denom );
