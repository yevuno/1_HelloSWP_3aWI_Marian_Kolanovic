using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Bitte geben Sie eine ganze Zahl ein:");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int number))
        {
            Console.WriteLine(ConsoleText("number"));

            string operation = Console.ReadLine();
            double result = 0;

            if (operation == "!" || operation == "sqrt")
            {
                if (operation == "!")
                {
                    result = Fakultaet(number);
                }
                else if (operation == "sqrt")
                {
                    result = SquareRootOperation.SquareRoot(number);
                }
            }
            else
            {
                Console.WriteLine("Bitte geben Sie eine zweite Zahl ein:");
                string secondInput = Console.ReadLine();

                if (double.TryParse(secondInput, out double secondNumber))
                {
                    result = PerformOperation(operation, number, secondNumber);
                }
                else
                {
                    Console.WriteLine("Die zweite Eingabe ist keine gültige Zahl.");
                    return;
                }
            }

            Console.WriteLine($"Ergebnis: {result}");
        }
        else
        {

            Console.WriteLine(ConsoleText("text"));

            string operation = Console.ReadLine();

            switch (operation)
            {
                case "1":
                    Console.WriteLine($"Ergebnis: {RemoveVowels(input)}");
                    break;
                case "2":
                    Console.WriteLine($"Ergebnis: {ReverseString(input)}");
                    break;
                case "3":
                    Console.WriteLine($"Ergebnis: {input.Length}");
                    break;
                default:
                    Console.WriteLine("Ungültige Auswahl.");
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
            return "Sie keine Zahl eingegeben oder eine Zeichenkette eingegeben. Was wollen Sie damit machen? \n 1) Alle Selbstlaute entfernen \n 2) Die Zeichenkette umdrehen \n 3) Zeichenkette Länge anzeigen";
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

        return new string(result);
    }
}