namespace Homework10._1
{
    internal class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Item(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public override string ToString()
        {
            return $"ID: {Id} Наименование: {Name}";
        }
    }
}
