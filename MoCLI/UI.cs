using MoCLI.Data.DTOs;
using MoCLI.Data.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoCLI
{
    public class UI
    {
        private readonly ICardRepo _repo;
        public UI(ICardRepo repo)
        {
            _repo = repo;
        }

        public async Task Start()
        {
            PrimaryLine("Welcome to MoCLI");
            PrimaryLine("Press:");
            while (true)
            {
                PrimaryLine("A to Answer");
                PrimaryLine("C to Create");
                var answer = Console.ReadLine();
                if (answer != null && answer.ToUpper() == "A")
                {
                    await Answer();
                }
                else if (answer != null && answer.ToUpper() == "C")
                {
                    await Create();
                }
                else
                {
                    PrimaryLine("Huh?");
                }
            }
        }

        public async Task Create()
        {
            PrimaryLine("Enter a prompt:");
            var prompt = Console.ReadLine();
            PrimaryLine("Enter an answer:");
            var answer = Console.ReadLine();
            PrimaryLine("");
            Console.WriteLine("Just to confirm:");
            Console.WriteLine($"Prompt: {prompt}\nAnswer: {answer}");
            PrimaryLine("Press N to cancel or any key to accept");
            var input = Console.ReadLine();
            if (input != null && input.ToUpper() == "N")
            {
                PrimaryLine("Cancelled");
            }
            else
            {
                var card = new CardCreateDTO { Prompt = prompt ?? "", Answer = answer ?? "" };
                await _repo.Create(card);
                GoodLine("Created");
            }
        }

        public async Task Answer()
        {
            var cards = await _repo.GetAllDue();
            foreach (var card in cards)
            {
                Console.WriteLine($"Prompt: {card.Prompt}");
                Console.ReadLine();
                Console.WriteLine($"Answer: {card.Answer}");
                GoodLine("C = Correct");
                BadLine("W = Wrong");
                var answer = Console.ReadLine();
                if (answer != null && answer.ToUpper() == "C")
                {
                    GoodLine("Marked correct");
                }
                else if (answer != null && answer.ToUpper() == "W")
                {
                    BadLine("Marked incorrect");
                }
            }
            GoodLine("All cards answered!");
        }

        public static void GoodLine(string msg)
        {
            ColouredWriteLine(msg, ConsoleColor.Green);
        }

        public static void BadLine(string msg)
        {
            ColouredWriteLine(msg, ConsoleColor.Red);
        }

        public static void PrimaryLine(string msg)
        {
            ColouredWriteLine(msg, ConsoleColor.DarkCyan);
        }

        private static void ColouredWriteLine(string msg, ConsoleColor color)
        {
            var previousColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ForegroundColor = previousColor;
        }
    }
}
