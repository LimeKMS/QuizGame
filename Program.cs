using System;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Transactions;

namespace QuizGame
{

    public class LinkedListNode
    {
        public string[] Data { get; set; }
        public LinkedListNode Next { get; set; }

        public LinkedListNode(string[] data)
        {
            Data = data;
            Next = null;
        }
    }

    public class LinkedList
    {
        public LinkedListNode Head { get; private set; }

        public void Add(string[] data)
        {
            var newNode = new LinkedListNode(data);
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                LinkedListNode current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        public void PrintAllNodes()
        {
            int i = 1;
            LinkedListNode current = Head;
            while (current != null)
            {
                Console.WriteLine("Question " + i + ":\n" + current.Data[1].PadRight(56) + "    Difficulty: " + current.Data[0]);
                Console.WriteLine("A. " + current.Data[2].PadRight(32) + "C. " + current.Data[4]);
                Console.WriteLine("B. " + current.Data[3].PadRight(32) + "D. " + current.Data[5]);
                Console.WriteLine("Answer: " + current.Data[6] + "\n");
                i++;
                current = current.Next;
            }
        }

        public void PrintAllEasy()
        {
            int i = 1;
            LinkedListNode current = Head;
            while (current != null)
            {
                if (current.Data[0] == "Easy")
                {
                    Console.WriteLine("Question " + i + ":\n" + current.Data[1].PadRight(56) + "    Difficulty: " + current.Data[0]);
                    Console.WriteLine("A. " + current.Data[2].PadRight(32) + "C. " + current.Data[4]);
                    Console.WriteLine("B. " + current.Data[3].PadRight(32) + "D. " + current.Data[5]);
                    Console.WriteLine("Answer: " + current.Data[6] + "\n");
                    i++;
                }

                current = current.Next;
            }
        }

        public void PrintAllMedium()
        {
            int i = 1;
            LinkedListNode current = Head;
            while (current != null)
            {
                if (current.Data[0] == "Medium")
                {
                    Console.WriteLine("Question " + i + ":\n" + current.Data[1].PadRight(56) + "    Difficulty: " + current.Data[0]);
                    Console.WriteLine("A. " + current.Data[2].PadRight(32) + "C. " + current.Data[4]);
                    Console.WriteLine("B. " + current.Data[3].PadRight(32) + "D. " + current.Data[5]);
                    Console.WriteLine("Answer: " + current.Data[6] + "\n");
                    i++;
                }

                current = current.Next;
            }
        }

        public void PrintAllHard()
        {
            int i = 1;
            LinkedListNode current = Head;
            while (current != null)
            {
                if (current.Data[0] == "Hard")
                {
                    Console.WriteLine("Question " + i + ":\n" + current.Data[1].PadRight(56) + "    Difficulty: " + current.Data[0]);
                    Console.WriteLine("A. " + current.Data[2].PadRight(32) + "C. " + current.Data[4]);
                    Console.WriteLine("B. " + current.Data[3].PadRight(32) + "D. " + current.Data[5]);
                    Console.WriteLine("Answer: " + current.Data[6] + "\n");
                    i++;
                }

                current = current.Next;
            }
        }

        public void updateQuestions(string path)
        {
            try
            {
                StreamWriter sw = new StreamWriter(path);
                LinkedListNode current = Head;
                while (current != null)
                {
                    if (current.Data[0] == "Easy")
                    {
                        sw.WriteLine(current.Data[0] + " | " + current.Data[1] + " | " + current.Data[2] + " | " + current.Data[3] + " | " + current.Data[4] + " | " + current.Data[5] + " | " + current.Data[6]);
                    }
                    current = current.Next;
                }
                current = Head;
                while (current != null)
                {
                    if (current.Data[0] == "Medium")
                    {
                        sw.WriteLine(current.Data[0] + " | " + current.Data[1] + " | " + current.Data[2] + " | " + current.Data[3] + " | " + current.Data[4] + " | " + current.Data[5] + " | " + current.Data[6]);
                    }
                    current = current.Next;
                }
                current = Head;
                while (current != null)
                {
                    if (current.Data[0] == "Hard")
                    {
                        sw.WriteLine(current.Data[0] + " | " + current.Data[1] + " | " + current.Data[2] + " | " + current.Data[3] + " | " + current.Data[4] + " | " + current.Data[5] + " | " + current.Data[6]);
                    }
                    current = current.Next;
                }

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                Console.WriteLine("Stack Trace: " + e.StackTrace);
            }
        }

        public void delete(int position)
        {
            LinkedListNode current = Head;
            LinkedListNode prev = Head;

            for (int i = 1; i <= position; i++)
            {
                if (i == 1 && position == 1)
                {
                    Head = current.Next;
                }
                else
                {
                    if (i == position)
                    {
                        prev.Next = current.Next;
                        Console.WriteLine("\nQuestion has been deleted!\n");
                    }
                    else
                    {
                        prev = current;
                        current = current.Next;
                    }
                }

            }


        }

    }



    class Program
    {
        public static string filename = "Questions.txt";
        public static string projectDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
        public static string filePath = Path.Combine(projectDirectory, filename);

        static LinkedList Questions = new LinkedList();


        public static void ReadQuestions()
        {
            try
            {
                Questions = new LinkedList();
                StreamReader sr = new StreamReader(filePath);
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] parts = line.Split('|');
                    for (int i = 0; i < parts.Length; i++)
                    {
                        parts[i] = parts[i].Trim();
                    }
                    Questions.Add(parts);

                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                Console.WriteLine("Stack Trace: " + e.StackTrace);
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

        public static string[] addQuestion()
        {
            String[] output = { "Difficulty", "Question", "A", "B", "C", "D", "Answer" };
            Console.WriteLine("\nInput Difficulty:");
            string userInput = Console.ReadLine();
            while (userInput != "Easy" && userInput != "Medium" && userInput != "Hard")
            {
                Console.WriteLine("\nInput A PROPER Difficulty:");
                userInput = Console.ReadLine();
            }
            output[0] = userInput;
            Console.WriteLine("\nInput Question:");
            output[1] = Console.ReadLine();
            Console.WriteLine("\nInput Answer Option A:");
            output[2] = Console.ReadLine();
            Console.WriteLine("\nInput Answer Option B:");
            output[3] = Console.ReadLine();
            Console.WriteLine("\nInput Answer Option C:");
            output[4] = Console.ReadLine();
            Console.WriteLine("\nInput Answer Option D:");
            output[5] = Console.ReadLine();
            Console.WriteLine("\nInput Answer:");
            userInput = Console.ReadLine();
            while (userInput != output[2] && userInput != output[3] && userInput != output[4] && userInput != output[5])
            {
                Console.WriteLine("\nAnswer does not match any options inputted, please resubmit: ");
                userInput = Console.ReadLine();
            }
            output[6] = userInput;

            Console.WriteLine("\nThe question you wish to add:");
            Console.WriteLine("\n" + output[1].PadRight(56) + "    Difficulty: " + output[0]);
            Console.WriteLine("A. " + output[2].PadRight(32) + "C. " + output[4]);
            Console.WriteLine("B. " + output[3].PadRight(32) + "D. " + output[5]);
            Console.WriteLine("Answer: " + output[6] + "\n");

            while (1 > 0)
            {
                Console.Write("\nDo you wish to add this question to the question list? (Y/N): ");
                userInput = Console.ReadLine();
                if (userInput == "Y")
                {
                    return output;
                }
                else if (userInput == "N")
                {
                    Console.Write("\nDo you still wish to add a new to the list instead? (Y/N): ");
                    userInput = Console.ReadLine();
                    if (userInput == "Y")
                    {
                        return addQuestion();
                    }
                    else if (userInput == "N")
                    {
                        return null;
                    }

                }

            }

        }

        public static void deleteQuestion()
        {


            int i = 0;
            int input = 0;
            Boolean valid = false;
            LinkedListNode current = Questions.Head;
            while (current != null)
            {
                i++;
                current = current.Next;
            }

            Questions.PrintAllNodes();
            Console.Write("\nAre you sure you want to delete a question (Y/N)?: ");
            string userInput = Console.ReadLine();
            while (valid == false)
            {
                switch (userInput)
                {
                    case "Y":
                        Console.Write("\nInput the question you want deleted: ");
                        userInput = Console.ReadLine();

                        try
                        {
                            input = Int32.Parse(userInput);
                        }
                        catch
                        {
                            input = 0;
                        }

                        if (input >= 1 && input <= i)
                        {
                            Questions.delete(input);
                            valid = true;
                        }
                        else
                        {
                            while (1 > 0)
                            {
                                Console.Write("\nInvalid Input!!\n\nInput the question you want deleted: ");
                                userInput = Console.ReadLine();
                                try
                                {
                                    input = Int32.Parse(userInput);
                                }
                                catch
                                {
                                    input = 0;
                                }

                                if (input >= 1 && input <= i)
                                {
                                    Questions.delete(input);
                                    valid = true;
                                    break;
                                }

                            }
                        }
                        break;
                    case "N":
                        valid = true;
                        break;
                    default:
                        Console.Write("\nPlease answer properly (Y/N)?: ");
                        userInput = Console.ReadLine();
                        break;
                }

            }


        }

        public static void AdminPage()
        {
            bool isRunning = true; // This flag controls the loop
            Console.WriteLine("\n\nYou have accessed the administer system.");
            Console.WriteLine("\nInput options:");
            Console.WriteLine("0) Pull up this list again");
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
                Console.WriteLine("");

                switch (userInput)
                {
                    case "0":
                        Console.WriteLine("\nInput options:");
                        Console.WriteLine("0) Pull up this list again");
                        Console.WriteLine("1) Display All questions.");
                        Console.WriteLine("2) Display All easy questions.");
                        Console.WriteLine("3) Display All medium questions.");
                        Console.WriteLine("4) Display All hard questions.");
                        Console.WriteLine("5) Add a question.");
                        Console.WriteLine("6) Remove a question.");
                        Console.WriteLine("7) Exit to the main menu.");
                        break;
                    case "1":
                        Questions.PrintAllNodes();
                        break;
                    case "2":
                        Questions.PrintAllEasy();
                        break;
                    case "3":
                        Questions.PrintAllMedium();
                        break;
                    case "4":
                        Questions.PrintAllHard();
                        break;
                    case "5":
                        String[] add = addQuestion();
                        if (add != null)
                        {
                            Questions.Add(add);
                            Questions.updateQuestions(filePath);
                            Console.WriteLine("\nNew Question has been added!\n");
                        }
                        goto case "0";
                    case "6":
                        deleteQuestion();
                        Questions.updateQuestions(filePath);
                        goto case "0";
                    case "7":
                        Console.WriteLine("\nHello! Welcome to the Quiz Game Show.\nIf you have any questions, just ask about the rules or, if you are ready to start, just say start.\nType 'exit' to stop at any time.");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("\nInvalid Input!\n");
                        break;

                }
            }
        }

        public static void Quiz()
        {

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
                else if (userInput.ToLower().Contains("start"))
                {

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
