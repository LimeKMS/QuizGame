using System;
using System.IO;

namespace QuizGame
{
    class Program
    {
        public static string filename = "Questions.txt";
        public static string filePath = Path.Combine(Directory.GetCurrentDirectory(), filename);

        public static void ReadQuestions()
        {
            try
            {
                StreamReader sr = new StreamReader(filePath);
                string line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public static void WriteRules()
        {
            Console.WriteLine("\nRules of the Quiz Game:");
            Console.WriteLine("1. Each correct answer gives you 1 point.");
            Console.WriteLine("2. There is no penalty for wrong answers.");
            Console.WriteLine("3. There are 10 questions, in order to win, you must answer 7 questions correctly.");
            Console.WriteLine("4. The first 4 questions are easy, the 2nd 3 questions are of medium difficulty, the last 3 are hard questions.");
            Console.WriteLine("5. The questions can very from history to music trivia.");
            Console.WriteLine("6. The questions are all multiple choice and you can answer with either the answer letter or the full answer.");
            Console.WriteLine("7. Type 'start' to start the game.");
            Console.WriteLine("8. Type 'exit' to end the game.\n\n");
            // Add more rules as needed
        }

        public static void AdminPage()
        {
            bool isRunning = true; // This flag controls the loop
            Console.WriteLine("\n\nYou have accessed the administer system.");
            Console.WriteLine("\nInput options:");
            Console.WriteLine("1) Display All questions.");
            Console.WriteLine("2) Display All easy questions.");
            Console.WriteLine("3) Display All medium questions.");
            Console.WriteLine("4) Display All hard questions.");
            Console.WriteLine("5) Add a question.");
            Console.WriteLine("6) Remove a question.");
            Console.WriteLine("7) Exit to the main menu.");
            while (isRunning)
            {
                Console.Write("Enter your input: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                    case "7":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("\nInvalid Input!\n");
                        break;

                }
            }
        }

        static void Main(string[] args)
        {
            bool isRunning = true; // This flag controls the loop

            ReadQuestions();

            Console.WriteLine("\nHello! Welcome to the Quiz Game Show.\nIf you have any questions, just ask about the rules or, if you are ready to start, just say start.\nType 'exit' to stop at any time.");

            while (isRunning)
            {
                Console.Write("Enter your input: ");
                string userInput = Console.ReadLine();

                // Check if the user wants to exit
                if (userInput.ToLower() == "exit")
                {
                    isRunning = false;
                }
                else if (userInput.ToLower().Contains("rules"))
                {
                    WriteRules();
                }
                else if (userInput.Contains("Admin Mode X22"))
                {
                    AdminPage();
                }
                else
                {
                    Console.WriteLine("You entered: " + userInput);
                }
            }

            Console.WriteLine("Program has ended. Press any key to exit.");
            Console.ReadKey(); // Wait for user input before closing
        }
    }
}
