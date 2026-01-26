using System;
using System.Collections.Generic;

class Program
{
    static List<string> tasks = new List<string>();

    static void Main()
    {
        Console.WriteLine("Velkommen til ToDoCLI - din konsol To-Do App!");
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nVælg en mulighed:");
            Console.WriteLine("1. Tilføj opgave");
            Console.WriteLine("2. Fjern opgave");
            Console.WriteLine("3. Vis alle opgaver");
            Console.WriteLine("4. Afslut");
            Console.Write("Indtast nummer: ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    RemoveTask();
                    break;
                case "3":
                    ShowTasks();
                    break;
                case "4":
                    running = false;
                    Console.WriteLine("Farvel!");
                    break;
                default:
                    Console.WriteLine("Ugyldigt valg, prøv igen.");
                    break;
            }
        }
    }

    static void AddTask()
    {
        Console.Write("Skriv opgaven: ");
        string task = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(task))
        {
            tasks.Add(task);
            Console.WriteLine($"Opgave '{task}' er tilføjet!");
        }
        else
        {
            Console.WriteLine("Opgaven må ikke være tom.");
        }
    }

    static void RemoveTask()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Ingen opgaver at fjerne.");
            return;
        }

        ShowTasks();
        Console.Write("Indtast nummer på opgave der skal fjernes: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= tasks.Count)
        {
            string removed = tasks[index - 1];
            tasks.RemoveAt(index - 1);
            Console.WriteLine($"Opgave '{removed}' er fjernet!");
        }
        else
        {
            Console.WriteLine("Ugyldigt nummer.");
        }
    }

    static void ShowTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Ingen opgaver endnu.");
            return;
        }

        Console.WriteLine("\nDine opgaver:");
        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tasks[i]}");
        }
    }
}
