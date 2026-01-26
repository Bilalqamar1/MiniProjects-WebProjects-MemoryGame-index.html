using System;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] options = { "rock", "paper", "scissors" };
            Random rand = new Random();

            Console.WriteLine("Velkommen til Rock-Paper-Scissors!");
            string playAgain;
            do
            {
                Console.Write("Vælg rock, paper eller scissors: ");
                string playerChoice = Console.ReadLine().ToLower();
                string computerChoice = options[rand.Next(options.Length)];

                Console.WriteLine($"Computer valgte: {computerChoice}");

                if (playerChoice == computerChoice)
                    Console.WriteLine("Uafgjort!");
                else if ((playerChoice == "rock" && computerChoice == "scissors") ||
                         (playerChoice == "paper" && computerChoice == "rock") ||
                         (playerChoice == "scissors" && computerChoice == "paper"))
                    Console.WriteLine("Du vandt! 🎉");
                else
                    Console.WriteLine("Du tabte 😢");

                Console.Write("Vil du spille igen? (y/n): ");
                playAgain = Console.ReadLine().ToLower();
            } while (playAgain == "y");

            Console.WriteLine("Tak for spillet!");
        }
    }
}
