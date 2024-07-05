namespace EntityFrameworkConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                ShowMenu();
                var input = Console.ReadLine();

                switch (input)
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
                        break;
                    case "8":
                        break;
                    case "9":
                        break;
                    case "10":
                        break;
                    case "11":
                        break;
                    case "12":
                        break;
                    case "13":
                        break;
                    case "14":
                        break;
                    case "15":
                        break;
                    case "0":
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input");
                        Console.ResetColor();
                        break;
                }
            }
        }
        private static void ShowMenu()
        {
            Console.WriteLine("""
                              0. Exit
                              1. Show All Libraries
                              2. Show All Books
                              3. Show All Authors
                              4. Show Books by Library
                              5. Show Books by Author
                              6. Show Authors by Books
                              7. Show All Books with Authors
                              8. Show All Libraries with Books
                              9. Add Library
                              10. Add Book
                              11. Add Author
                              12. Assign Author to Book
                              13. Find Book by Title
                              14. Find Author by Name
                              15. Find Books By Genre
                              """);
            Console.WriteLine();
            Console.Write("Enter menu number : ");
        }

        private static string GetInput(string inputMessage)
        {
            Console.Write(inputMessage);
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Input can't be empty");
                Console.ResetColor();
                return GetInput(inputMessage);
            }
            return input;
        }

        private static int GetValidInput(string inputMessage)
        {
            Console.Write(inputMessage);

            string input = Console.ReadLine();
            bool isValid = int.TryParse(input, out int result);

            if (!isValid || result < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input");
                Console.ResetColor();
                return GetValidInput(inputMessage);
            }
            return result;
        }
    }
}
