namespace Homework14.Models
{
    public class Product : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"ID = {ID}, Name: {Name} - {Description}, StockQuantity = {StockQuantity}, Price = {Price}";
        }
    }
}
