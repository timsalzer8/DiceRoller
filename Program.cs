using System;
using System.Threading;


class Program
{
    static void Main()
    {
        while (true) // Schleife beginnt
        {
            Console.WriteLine("Welcome to the Dice Roller!");

            // Frage: Wie viele Seiten hat der Würfel?
            Console.Write("How many sides does your dice have? ");
            string input = Console.ReadLine();
            bool success = int.TryParse(input, out int sides);

            if (!success || sides <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive number.");
                continue;
            }

            // Frage: Wie oft würfeln?
            Console.Write("How many times do you want to roll the dice? ");
            string countInput = Console.ReadLine();
            bool countSuccess = int.TryParse(countInput, out int count);

            if (!countSuccess || count <= 0)
            {
                Console.WriteLine("Invalid number of rolls.");
                continue;
            }

            Random rnd = new Random(); // Zahlengenerator (einmal erstellen)
            int total = 0; // Variable für die Summe der Würfe

            Console.WriteLine($"\nRolling a d{sides} {count} time(s):");

            for (int i = 1; i <= count; i++)
            {
                Console.Write($"Roll {i}: ");

                // Flackernde Zahl animieren (erscheint an derselben Stelle)
                for (int j = 0; j < 8; j++)
                {
                    int fake = rnd.Next(1, sides + 1);
                    Console.Write($"{fake}");
                    Thread.Sleep(80); // Verzögerung in Milisekunden

                    // Überschreibe die vorherige Zahl mit Backspace
                    Console.Write(new string('\b', fake.ToString().Length));
                }

                // Echter Wurf
                int result = rnd.Next(1, sides + 1);
                Console.WriteLine($"{result}");

                total += result;
            }



            Console.WriteLine($"\nTotal sum of all rolls: {total}");

            Console.Write("\nDo you want to roll again? (y/n): ");
            string answer = Console.ReadLine().ToLower();

            if (answer != "y")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
        }
    }
}