using System;

class Program
{
    static void Main()
    {
        string input;

        Console.WriteLine("Input:");

        while (true)
        {
            input = Console.ReadLine();

            if (input.Equals("Beenden", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
            else if (int.TryParse(input, out int number))
            {
                string typeOfNumber = number.GetType().ToString();
                Console.WriteLine($"Eingegebene Nummer: {number}, \n Datentyp: {typeOfNumber} \n\n'Beenden' zum Beenden.");

                continue;
            }
            else
            {
                Console.WriteLine("Eingabe ist keine Nummer. Bitte erneut eingeben.");
                continue;
            }



            Console.WriteLine($"Eingabe abgeschlossen: {input}");
        }

        Console.WriteLine("Ende.");
    }
}
