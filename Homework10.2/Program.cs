using System.Text;

namespace Homework10._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Librarian librarian = new();

            while (true)
            {
                PrintMenu();
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        librarian.AddBook();
                        break;
                    case ConsoleKey.D2:
                        librarian.ListOfBooks();
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("Завершение работы");
                        librarian.Dispose();
                        return;
                    default:
                        break;
                }
            }
        }

        private static void PrintMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("'1' - добавить книгу");
            sb.AppendLine("'2' - вывести список непрочитанного");
            sb.AppendLine("'3' - выйти");
            Console.WriteLine(sb.ToString());
        }
    }
}
