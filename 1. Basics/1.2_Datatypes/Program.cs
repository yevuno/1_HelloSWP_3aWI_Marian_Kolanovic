using System;

class Program
{
    static void Main()
    {
        string input;
        Console.WriteLine("\n Verfügbare Datentypen: \n- int \n- double \n- float \n- decimal \n- bool \n- char \n- string \n\n'Beenden' zum Beenden.");

        while (true)
        {
            Console.WriteLine("Input:");
            input = Console.ReadLine();

            if (input.Equals("Beenden", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            if (int.TryParse(input, out int intNumber))
            {
                Console.WriteLine($"Input: {intNumber} \nDatentyp: {intNumber.GetType()} \n");
            }
            else if (decimal.TryParse(input, out decimal decimalNumber))
            {
                Console.WriteLine($"Input: {decimalNumber} \nDatentyp: {decimalNumber.GetType()} \n");
            }
            else if (float.TryParse(input, out float floatNumber))
            {
                Console.WriteLine($"Input: {floatNumber} \nDatentyp: {floatNumber.GetType()} \n");
            }
            else if (double.TryParse(input, out double doubleNumber))
            {
                Console.WriteLine($"Input: {doubleNumber} \nDatentyp: {doubleNumber.GetType()} \n");
            }
            else if (bool.TryParse(input, out bool boolValue))
            {
                Console.WriteLine($"Input: {boolValue} \nDatentyp: {boolValue.GetType()} \n");
            }
            else if (char.TryParse(input, out char charValue))
            {
                Console.WriteLine($"Input: {charValue} \nDatentyp: {charValue.GetType()} \n");
            }
            else
            {
                Console.WriteLine($"Input: {input} \nDatentyp: {input.GetType()} \n");
            }

            Console.WriteLine("'Beenden' zum Beenden oder gib eine andere Eingabe ein.");
        }

        Console.WriteLine("Ende.");
    }
}
