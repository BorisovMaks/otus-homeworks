using System.Collections.ObjectModel;

namespace Homework10._1
{
    internal class Shop : IShop
    {
        private int _nextItemId = default;
        public ObservableCollection<Item> Items { get; set; }

        public Shop()
        {
            Items = new ObservableCollection<Item>();
        }

        public void Add(string nameItem)
        {
            Items.Add(new Item(Items.Count, nameItem));
            _nextItemId++;
        }

        public void Remove(int id)
        {
            if (Items.Count == 0)
            {
                Console.WriteLine("Список товаров пуст");
                return;
            }

            var item = Items.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                Console.WriteLine($"Товар с id '{id}' не найден");
                return;
            }
            Items.Remove(item);
        }
    }
}
