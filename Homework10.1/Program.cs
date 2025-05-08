namespace Homework10._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var shop = new Shop();
            var customer = new Customer();

            shop.Items.CollectionChanged += customer.OnItemChanged;
            ShowMainMenu();

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.A:
                        AddItem(shop);
                        break;
                    case ConsoleKey.D:
                        Remove(shop);
                        break;
                    case ConsoleKey.X:
                        shop.Items.CollectionChanged -= customer.OnItemChanged;
                        return;
                    default:
                        break;
                }
            }
        }

        private static void Remove(Shop shop)
        {
            if (shop.Items.Count == 0)
            {
                Console.WriteLine("Список товаров пуст");
                return;

            }

            bool flag = true;
            Console.WriteLine("Введите Id товара, который хотите удалить");
            var id = Console.ReadLine();

            while (flag)
            {
                if (!string.IsNullOrEmpty(id) && int.TryParse(id, out var intId))
                {
                    shop.Remove(intId);
                    Console.WriteLine("Обновленный список товаров:");
                    foreach (var item in shop.Items)
                    {
                        Console.WriteLine(item.ToString());
                    }
                    flag = false;
                    ShowMainMenu();
                }
                else
                {
                    Console.WriteLine("Id должен быть числом");
                    Console.WriteLine("Введите Id товара, который хотите удалить");
                    id = Console.ReadLine();

                }
            }
        }

        private static void ShowMainMenu()
        {
            Console.WriteLine("Нажмите 'A' чтобы добавить товар");
            Console.WriteLine("Нажмите 'D' чтобы удалить товар");
            Console.WriteLine("Нажмите 'X' чтобы выйти");
        }

        static void AddItem(Shop shop)
        {
            shop.Add($"Товар от {DateTime.Now.ToString()}");
        }
    }
}
