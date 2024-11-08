using System;

class Program
{
    static void Main(string[] args)
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

            Console.WriteLine($"Eingabe abgeschlossen: {input}");
        }

        Console.WriteLine("Ende.");
    }
}
