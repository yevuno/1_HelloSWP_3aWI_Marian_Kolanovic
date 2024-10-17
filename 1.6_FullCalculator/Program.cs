using System;

class Program
{
    static List<string> operations = new List<string>
    {
        "(*)" + " Multiplikation",
        "(/)" + " Dividieren",
        "(+)" + " Addieren",
        "(-)" + " Subtraktion",
        "(^)" + " Potenzieren",
        "(sqrt)" + " Wurzel ziehen"
    };

    static void Main()
    {
        Console.WriteLine("Verfügbare mathematische Operationen:");
        foreach (var operation in operations)
        {
            Console.WriteLine(operation);
        }

        Console.Write("Wähle die Operation: ");
        string chosenOperation = Console.ReadLine();

        if (chosenOperation == "(sqrt)")
        {
            Console.Write("Gib die Zahl ein: ");
            double input = Convert.ToDouble(Console.ReadLine());
            double result = SquareRootOperation.SquareRoot(input);
            Console.WriteLine($"Ergebnis: √{input} = {result}");
        }
        else
        {
            Console.Write("Gib die erste Zahl ein: ");
            double input1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Gib die zweite Zahl ein: ");
            double input2 = Convert.ToDouble(Console.ReadLine());

            double result = MathOperations.PerformOperation(chosenOperation, input1, input2);
            Console.WriteLine($"Ergebnis: {result}");
        }
    }
}

static class MathOperations
{
    public static double PerformOperation(string operation, double input1, double input2)
    {
        switch (operation)
        {
            case "(*)":
                return input1 * input2;
            case "(/)":
                if (input2 != 0)
                    return input1 / input2;
                else
                    throw new DivideByZeroException("Division durch Null ist nicht erlaubt");
            case "(+)":
                return input1 + input2;
            case "(-)":
                return input1 - input2;
            case "(^)":
                return Math.Pow(input1, input2);
            default:
                throw new ArgumentException("Ungültige Operation");
        }
    }
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
