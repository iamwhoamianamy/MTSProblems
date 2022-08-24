using System;
using System.Globalization;

class Program
{
    static readonly IFormatProvider _ifp = CultureInfo.InvariantCulture;

    class Number
    {
        readonly int _number;

        public Number(int number)
        {
            _number = number;
        }

        public override string ToString()
        {
            return _number.ToString(_ifp);
        }

        // Без перегрузки оператора он будет работать как обычная конкатенация строк (10 + 5 = 105)
        public static string operator +(Number a, string b) =>
            (a._number + Int32.Parse(b)).ToString();
    }

    static void Main(string[] args)
    {
        int someValue1 = 10;
        int someValue2 = 5;

        string result = new Number(someValue1) + someValue2.ToString(_ifp);
        Console.WriteLine(result);
        Console.ReadKey();
    }
}
