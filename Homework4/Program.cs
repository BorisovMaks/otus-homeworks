namespace Homework4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new("a", "b", "c");
            stack.Add("d");
            Stack stack2 = new("1", "2", "3");
            Console.WriteLine($"size = {stack.Size}, Top = '{stack.Top}'");
            var deleted = stack.Pop();
            Console.WriteLine($"Извлек верхний элемент '{deleted}' Size = {stack.Size}");

            var stack3 = Stack.Merge(stack, stack2);

            Console.WriteLine($"size = {stack3.Size}, Top = '{stack3.Top}'");
            stack3.PrintStackList();

            var s = Stack.Concat(new Stack("a", "b", "c"), new Stack("1", "2", "3"), new Stack("А", "Б", "В"));
            Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");
            s.PrintStackList();
            Console.ReadKey();
        }
    }
}
