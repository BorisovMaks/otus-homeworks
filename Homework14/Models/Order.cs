namespace Homework14.Models
{
    public class Order : ModelBase
    {
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"ID = {ID}, CustomerID = {CustomerID}, ProductID = {ProductID}, Quantity = {Quantity}";
        }
    }
}
