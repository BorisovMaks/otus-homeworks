namespace Homework16
{
    internal class Node
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public Node? Left { get; set; } = null;
        public Node? Right { get; set; } = null;

        public Node(string name, int salary)
        {
            Name = name;
            Salary = salary;
        }
    }
}
