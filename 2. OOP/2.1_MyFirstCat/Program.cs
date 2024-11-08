using System;

namespace _2._1_MyFirstCat
{
    class Program
    {
        static void Main(string[] args)
        {
            var myCat = new Cat { Color = "Schwarz", Birthdate = new DateTime(2008, 1, 23) };
            myCat.CalculateAge();

            Console.WriteLine($"Die Katze hat die Farbe: {myCat.Color}");
            Console.WriteLine($"Die Katze ist {myCat.Age} Jahre alt.");
        }
    }
}
