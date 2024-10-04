using System;

public static class MathFunctions
{
    public static int Square(int number)
    {
        return number * number;
    }

    public static long Factorial(int number)
    {
        if (number < 0)
            throw new ArgumentOutOfRangeException("number", "Eine negative Zahl wurde eingegeben.");

        long result = 1;
        for (int i = 1; i <= number; i++)
        {
            result *= i;
        }
        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Wähle eine Operation:");
        Console.WriteLine("1: Quadrat");
        Console.WriteLine("2: Fakultät");
        
        string choice = Console.ReadLine();

        Console.Write("Gebe eine ganze Zahl ein: ");
        int number;
        
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.Write("Gib eine gültige ganze Zahl ein: ");
        }

        try
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine($"Das Quadrat von {number} ist: {MathFunctions.Square(number)}");
                    break;
                case "2":
                    Console.WriteLine($"Die Fakultät von {number} ist: {MathFunctions.Factorial(number)}");
                    break;
                default:
                    Console.WriteLine("Ungültige Auswahl. Bitte wähle 1 oder 2.");
                    break;
            }
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
