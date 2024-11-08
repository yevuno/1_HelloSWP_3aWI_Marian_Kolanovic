using System;

class Program
{
    static void Main()
    {
        string choice;
        do
        {

            Console.WriteLine("1: Wörter Zählen\n2: Text umkehren\n\nWähle eine Option (1 oder 2):");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Gib einen Text ein:");
                    string inputCountWords = Console.ReadLine();
                    Console.WriteLine($"Anzahl Wörter: {StringFunctions.CountWords(inputCountWords)}");
                    break;
                case "2":
                    Console.WriteLine("Gib einen Text ein:");
                    string inputReverse = Console.ReadLine();
                    Console.WriteLine($"Umgekehrt: {StringFunctions.Reverse(inputReverse)}");
                    break;
                default:
                    Console.WriteLine("Ungültige Auswahl. Bitte wähle 1 oder 2.");
                    break;
            }
        } while (choice != "1" && choice != "2");
    }
}

static class StringFunctions
{
    public static int CountWords(string input)
    {
        int count = 0;
        bool inWord = false;

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] != ' ')
            {
                if (!inWord)
                {
                    count++;
                    inWord = true;
                }
            }
            else
            {
                inWord = false;
            }
        }

        return count;
    }

    public static string Reverse(string input)
    {
        string result = "";

        for (int i = input.Length; i > 0; i--)
        {
            result += input[i - 1];
        }

        return result;
    }
}
