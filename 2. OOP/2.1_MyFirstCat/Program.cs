
using System;

namespace _2._1_MyFirstCat
{
    class Program
    {
        static void Main(string[] args)
        {
            var myCat = new Cat();
            myCat.SetColor("Schwarz");
            myCat.SetBirthdate(new DateTime(2008, 1, 23));
            myCat.CalculateAge();

            var catInfo = myCat.GetCatInfo();
            Console.WriteLine($"Die Katze hat die Farbe {catInfo.Item1}");
            Console.WriteLine($"Die Katze ist {myCat.Age} Jahre alt.");
        }
    }
}