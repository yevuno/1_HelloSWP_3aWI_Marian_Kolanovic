using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Bitte geben Sie eine ganze Zahl ein:");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int number))
            {
                double result = HandleMathOperation(number);
                Console.WriteLine($"Ergebnis: {result}");
            }
            else
            {
                HandleStringOperation(input);
            }
        }
    }

    public static double HandleMathOperation(int number)
    {
        while (true)
        {
            Console.WriteLine(ConsoleText("number"));
            string operation = Console.ReadLine();
            double result = 0;

            if (operation == "!" || operation == "sqrt")
            {
                try
                {
                    if (operation == "!")
                    {
                        result = Fakultaet(number);
                    }
                    else if (operation == "sqrt")
                    {
                        result = SquareRootOperation.SquareRoot(number);
                    }
                    return result;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Fehler: {ex.Message}. Bitte versuchen Sie es erneut.");
                }
            }
            else
            {
                Console.WriteLine("Bitte geben Sie eine zweite Zahl ein:");
                string secondInput = Console.ReadLine();

                if (double.TryParse(secondInput, out double secondNumber))
                {
                    try
                    {
                        result = PerformOperation(operation, number, secondNumber);
                        return result;
                    }
                    catch (DivideByZeroException ex)
                    {
                        Console.WriteLine($"Fehler: {ex.Message}. Bitte geben Sie eine andere Zahl ein.");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Fehler: {ex.Message}. Bitte versuchen Sie es erneut.");
                    }
                }
                else
                {
                    Console.WriteLine("Die zweite Eingabe ist keine gültige Zahl. Bitte erneut eingeben.");
                }
            }
        }
    }

    public static void HandleStringOperation(string input)
    {
        while (true)
        {
            Console.WriteLine(ConsoleText("text"));
            string operation = Console.ReadLine();

            switch (operation)
            {
                case "1":
                    Console.WriteLine($"Ergebnis: {RemoveVowels(input)}");
                    return;
                case "2":
                    Console.WriteLine($"Ergebnis: {ReverseString(input)}");
                    return;
                case "3":
                    Console.WriteLine($"Ergebnis: {input.Length}");
                    return;
                default:
                    Console.WriteLine("Ungültige Auswahl. Bitte erneut versuchen.");
                    break;
            }
        }
    }

    public static double PerformOperation(string operation, double input1, double input2)
    {
        switch (operation)
        {
            case "*":
                return input1 * input2;
            case "/":
                if (input2 != 0)
                    return input1 / input2;
                else
                    throw new DivideByZeroException("Division durch Null ist nicht erlaubt");
            case "+":
                return input1 + input2;
            case "-":
                return input1 - input2;
            default:
                throw new ArgumentException("Ungültige Operation");
        }
    }

    public static int Fakultaet(int n)
    {
        if (n < 0) throw new ArgumentException("Die Fakultät einer negativen Zahl ist nicht definiert.");
        if (n <= 1) return 1;
        return n * Fakultaet(n - 1);
    }

    static class SquareRootOperation
    {
        public static double SquareRoot(double input)
        {
            if (input < 0)
                throw new ArgumentException("Die Eingabe darf nicht negativ sein");
            return Math.Sqrt(input);
        }
    }

    public static string ConsoleText(string consoleChoice)
    {
        if (consoleChoice == "number")
        {
            return "Wähle eine mathematische Operation: \n + Addition \n * Multiplikation \n / Division \n ! Fakultät \n sqrt Wurzelziehen";
        }
        else if (consoleChoice == "text")
        {
            return "Sie haben keine Zahl eingegeben. Was wollen Sie damit machen? \n 1) Alle Selbstlaute entfernen \n 2) Die Zeichenkette umdrehen \n 3) Zeichenkette Länge anzeigen";
        }
        else
        {
            return "Ungültige Eingabe";
        }
    }

    public static string RemoveVowels(string input)
    {
        string vowels = "aeiouAEIOU";
        foreach (char c in vowels)
        {
            input = input.Replace(c.ToString(), "");
        }
        return input;
    }

    public static string ReverseString(string input)
    {
        string result = "";

        for (int i = input.Length; i > 0; i--)
        {
            result += input[i - 1];
        }

        return result;
    }
}
