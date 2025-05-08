namespace Homework11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] intsArray = [1, 2, 3, 4, 5, 6, 7, 8, 9];
            string[] stringsArray = ["один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять"];

            List<int> listInts = new([1, 2, 3, 4, 5, 6, 7, 8, 9]);
            List<string> listStrings = new(["один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять"]);


            Console.WriteLine(string.Join(", ", intsArray.Top(30)));
            Console.WriteLine(string.Join(", ", stringsArray.Top(30)));
            Console.WriteLine(string.Join(", ", listInts.Top(30)));
            Console.WriteLine(string.Join(", ", listStrings.Top(30)));

            List<Person> people =
            [
                new Person { Name = "Александр", Age = 25 },
                new Person { Name = "Борис", Age = 30 },
                new Person { Name = "Валерия", Age = 20 },
                new Person { Name = "Геннадий", Age = 41 },
                new Person { Name = "Дмитрий", Age = 18 },
                new Person { Name = "Светлана", Age = 29 },
                new Person { Name = "Тимофей", Age = 33 },
                new Person { Name = "Филипп", Age = 35 },
                new Person { Name = "Яков", Age = 28 }
            ];

            foreach (var person in people.Top(30, p => p.Age))
            {
                Console.WriteLine(person);
            }

            foreach (var person in people.Top(30, p => p.Name))
            {
                Console.WriteLine(person);
            }
        }
    }
}
