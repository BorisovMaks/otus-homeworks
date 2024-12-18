namespace Homework3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SetConsoleDefaultColors();
            QuadraticEquationModel equation = new ();

            bool flag = true;
            while (flag)
            {
                try
                {
                    Console.Clear();
                    equation.PrintExpression();

                    var key = Console.ReadKey();

                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        Console.Clear();
                        equation.ChangeIndex(-1);
                    }

                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        Console.Clear();
                        equation.ChangeIndex(1);
                    }

                    if (key.Key == ConsoleKey.Enter && !equation.AllIsSet)
                    {
                        equation.SetValue();
                    }

                    if (key.Key == ConsoleKey.Enter && equation.AllIsSet)
                    {
                        if (equation.TryGetResult(out var result))
                        {
                            Console.WriteLine(result);
                            flag = false;
                        }
                    }
                }
                catch (QuadraticEquationException ex)
                {
                    Console.BackgroundColor = ex.BackgroundColor;
                    Console.ForegroundColor = ex.ForegroundColor;
                    Console.WriteLine(ex.FormatData());
                    SetConsoleDefaultColors();

                    if (ex.Severity == Severity.Warning)
                    {
                        flag = false;
                    }

                    Console.ReadLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("Не предвиденная ошибка");
                    SetConsoleDefaultColors();
                    flag = false;
                }
            }
        }

        private static void SetConsoleDefaultColors()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

