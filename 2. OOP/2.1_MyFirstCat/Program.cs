using System;

namespace _2._1_MyFirstCat
{
    class Program
    {
        static void Main(string[] args)
        {
            Tierheim meinTierheim = new Tierheim();

            bool next = true;
            while (next)
            {
                var newCat = new Cat();

                Console.Write("Gib die Farbe der Katze ein: ");
                string color = Console.ReadLine();
                newCat.SetColor(color);

                Console.Write("Gib das Geburtsdatum der Katze ein (JJJJ-MM-TT): ");
                DateTime geburtsdatum;
                while (!DateTime.TryParse(Console.ReadLine(), out geburtsdatum))
                {
                    Console.Write("Ungültiges Datum! Bitte im Format JJJJ-MM-TT eingeben: ");
                }
                newCat.SetBirthdate(geburtsdatum);

                newCat.CalculateAge();

                meinTierheim.AddCat(newCat);

                Console.Write("Möchtest du eine weitere Katze hinzufügen? (Y/n): ");
                string answer = Console.ReadLine().ToLower();
                if (answer != "Y")
                {
                    next = false;
                }
            }

            Console.WriteLine("\nAlle Katzen im Tierheim:");
            meinTierheim.ShowCats();
        }
    }
}
