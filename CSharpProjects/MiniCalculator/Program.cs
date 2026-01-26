using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Velkommen til MiniCalculator!");
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nVælg operation:");
            Console.WriteLine("1. Addition (+)");
            Console.WriteLine("2. Subtraktion (-)");
            Console.WriteLine("3. Multiplikation (*)");
            Console.WriteLine("4. Division (/)");
            Console.WriteLine("5. Afslut");
            Console.Write("Indtast nummer: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PerformOperation("+");
                    break;
                case "2":
                    PerformOperation("-");
                    break;
                case "3":
                    PerformOperation("*");
                    break;
                case "4":
                    PerformOperation("/");
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Farvel!");
                    break;
                default:
                    Console.WriteLine("Ugyldigt valg, prøv igen.");
                    break;
            }
        }
    }

    static void PerformOperation(string op)
    {
        double num1, num2;
        Console.Write("Indtast første tal: ");
        while (!double.TryParse(Console.ReadLine(), out num1))
            Console.Write("Ugyldigt tal. Prøv igen: ");

        Console.Write("Indtast andet tal: ");
        while (!double.TryParse(Console.ReadLine(), out num2))
            Console.Write("Ugyldigt tal. Prøv igen: ");

        double result = 0;
        switch (op)
        {
            case "+": result = num1 + num2; break;
            case "-": result = num1 - num2; break;
            case "*": result = num1 * num2; break;
            case "/":
                if (num2 != 0)
                    result = num1 / num2;
                else
                {
                    Console.WriteLine("Fejl: Kan ikke dividere med 0!");
                    return;
                }
                break;
        }

        Console.WriteLine($"Resultat: {result}");
    }
}
