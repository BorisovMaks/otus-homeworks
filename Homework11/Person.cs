namespace Homework11
{
    internal class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"Имя: {Name}\tВозраст: {Age}";
        }
    }
}
