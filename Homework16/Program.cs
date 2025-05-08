namespace Homework16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node? root = null;

            while (true)
            {
                Console.WriteLine("Заполните информацию о сотрудниках. Для завершения ввода введите пустое имя сотрудника\n");
                while (true)
                {
                    Console.Write("Введите имя сотрудника: ");
                    
                    string? name = Console.ReadLine();
                    if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                    {
                        break;
                    }

                    Console.Write("Введите зарплату сотрудника: ");
                    if (!int.TryParse(Console.ReadLine(), out int salary))
                    {
                        Console.WriteLine("Внимание! Зарплата должна быть в виде целого числа. Попробуйте снова!");
                        continue;
                    }
                    root = Insert(root, name.Trim(), salary);
                }

                Console.WriteLine("\nСписок сотрудников, в порядке возрастания зарплат: ");
                SymmetricTreeTraversal(root);

                while (true)
                {
                    if (root == null)
                    {
                        Console.WriteLine("Список сотрудников пуст.");
                        break;
                    }

                    Console.Write("\nВведите размер зарплаты, для поиска сотрудника: ");
                    if (!int.TryParse(Console.ReadLine(), out int salaryToSearch))
                    {
                        Console.WriteLine("Некорректный ввод. Зарплата должна быть в виде целого числа. Попробуйте снова.");
                        continue;
                    }

                    string employee = FindSalary(root, salaryToSearch);
                    if (!string.IsNullOrEmpty(employee))
                    {
                        Console.WriteLine($"Сотрудника с зарплатой {salaryToSearch} зовут '{employee}'");
                    }
                    else
                    {
                        Console.WriteLine("Такой сотрудник не найден");
                    }

                    Console.Write("\nВведите 0 для начала нового ввода или 1 для нового поиска: ");

                    var key = Console.ReadKey();
                    switch (key.Key)
                    {
                        case ConsoleKey.D0:
                            root = null;
                            break;
                        case ConsoleKey.D1:
                            continue;
                    }
                }
            }
        }

        /// <summary>
        /// Вставить новый узел в дерево
        /// </summary>
        /// <param name="root">Узел дерева</param>
        /// <param name="name">Имя работника</param>
        /// <param name="salary">Зарплата сотрудника</param>
        /// <returns>узел</returns>
        public static Node Insert(Node? root, string name, int salary)
        {
            if (root == null)
            {
                return new Node(name, salary);
            }

            if (salary < root.Salary)
            {
                root.Left = Insert(root.Left, name, salary);
            }
            else
            {
                root.Right = Insert(root.Right, name, salary);
            }

            return root;
        }

        /// <summary>
        /// Симметричный обход дерева
        /// </summary>
        /// <param name="root">Узел дерева</param>
        public static void SymmetricTreeTraversal(Node? root)
        {
            if (root != null)
            {
                SymmetricTreeTraversal(root.Left);
                Console.WriteLine($"{root.Name} - {root.Salary}");
                SymmetricTreeTraversal(root.Right);
            }
        }

        /// <summary>
        /// Поиск сотрудника с искомой зарплатой
        /// </summary>
        /// <param name="root">Узел дерева</param>
        /// <param name="salary">Зарплата сотрудника</param>
        /// <returns>Имя сотрудника</returns>
        public static string FindSalary(Node? root, int salary)
        {
            if (root == null)
            {
                return string.Empty;
            }
            if (salary == root.Salary)
            {
                return root.Name;
            }
            if (salary < root.Salary)
            {
                return FindSalary(root.Left, salary);
            }
            return FindSalary(root.Right, salary);
        }
    }
}
