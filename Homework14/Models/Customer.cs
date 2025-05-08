namespace Homework14.Models
{
    public class Customer : ModelBase
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"Customer: {ID} - {FirstName} {LastName}, {Age}";
        }
    }
}
