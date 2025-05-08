namespace Homework9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var otusDictionary = new OtusDictionary();
            Console.WriteLine("Заполнение коллекции otusDictionary");
            for (int i = 0; i < 40; i++)
            {
                Console.WriteLine($"Key {i}; Value {i}");
                otusDictionary.Add(i, $"Некоторое значение {i}");
            }

            Console.WriteLine("Key 56; Value 56");
            otusDictionary.Add(56, "Некоторое значение 56");

            Console.WriteLine($"Получение значения 56 элемента коллекции: {otusDictionary.Get(56)}");

            otusDictionary.Get(156);
            Console.WriteLine();
            otusDictionary[65] = $"Некоторое значение 65";
            Console.WriteLine($"Индексированное значение: {otusDictionary[65]}");
        }
    }
}
