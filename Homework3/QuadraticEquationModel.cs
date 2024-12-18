using System.Text;

namespace Homework3
{
    public class QuadraticEquationModel
    {
        private int _discriminant => (int)(Math.Pow(B, 2)) - (4 * A * C);
        private string _qudraticEquation = $"Квадратное уравнение = 'a * x^2 + b * x + c = 0'";
        private int _currentIndex = 0;

        public int A { get; private set; } = default;
        public int B { get; private set; } = default;
        public int C { get; private set; } = default;
        public bool AIsSet { get; private set; }
        public bool BIsSet { get; private set; }
        public bool CIsSet { get; private set; }
        public bool AllIsSet => AIsSet && BIsSet && CIsSet;

        public QuadraticEquationModel()
        {

        }

        /// <summary>
        /// Установить значения
        /// </summary>
        public void SetValue()
        {
            switch (_currentIndex)
            {
                case 0:
                {
                    SetA();
                    Console.ReadLine();
                    break;
                }
                case 1:
                {
                    SetB();
                    Console.ReadLine();
                    break;
                }
                case 2:
                {
                    SetC();
                    Console.ReadLine();
                    break;
                }
            }
        }

        /// <summary>
        /// Проверка и получение результата решения квадратного уравнения
        /// </summary>
        /// <param name="result">результат решения</param>
        /// <returns>True - OK | False - error</returns>
        public bool TryGetResult(out string result)
        {
            PrintExpression();
            result = string.Empty;
            var checkDefaultValue = A != default;

            if (checkDefaultValue)
            {
                result = Calculate();
            }

            return checkDefaultValue ? true : false;
        }

        /// <summary>
        /// Вывод выражения
        /// </summary>
        public void PrintExpression() => BuildMessage();

        /// <summary>
        /// Изменение индекса при выборе необходимого члена выражения
        /// </summary>
        /// <param name="delta">Изменение индекса</param>
        public void ChangeIndex(int delta)
        {
            _currentIndex += delta;

            if (_currentIndex > 2)
            {
                _currentIndex = 0;
            }

            if (_currentIndex < 0)
            {
                _currentIndex = 2;
            }
        }

        /// <summary>
        /// Создание и изменение уравнения для вывода на консоль
        /// </summary>
        private void BuildMessage()
        {
            StringBuilder sb = new();

            sb.AppendLine(_qudraticEquation);
            WriteA(sb);
            WriteB(sb);
            WriteC(sb);

            Console.WriteLine(sb.ToString());
        }

        private void WriteC(StringBuilder sb)
        {
            if (_currentIndex == 2)
            {
                if (CIsSet)
                {
                    sb.AppendLine($">c:{C.ToString()}");
                }
                else
                {
                    sb.AppendLine($">c: не задано");
                }
            }
            else
            {
                if (CIsSet)
                {
                    sb.AppendLine($"c:{C.ToString()}");
                }
                else
                {
                    sb.AppendLine($"c: не задано");
                }
            }
        }

        private void WriteB(StringBuilder sb)
        {
            if (_currentIndex == 1)
            {
                if (BIsSet)
                {
                    sb.AppendLine($">b:{B.ToString()}");
                }
                else
                {
                    sb.AppendLine($">b: не задано");
                }
            }
            else
            {
                if (BIsSet)
                {
                    sb.AppendLine($"b:{B.ToString()}");
                }
                else
                {
                    sb.AppendLine($"b: не задано");
                }
            }
        }

        private void WriteA(StringBuilder sb)
        {
            if (_currentIndex == 0)
            {
                if (AIsSet)
                {
                    sb.AppendLine($">a:{A.ToString()}");
                }
                else
                {
                    sb.AppendLine($">a: не задано");
                }
            }
            else
            {
                if (AIsSet)
                {
                    sb.AppendLine($"a:{A.ToString()}");
                }
                else
                {
                    sb.AppendLine($"a: не задано");
                }
            }
        }

        /// <summary>
        /// Задает значение 'А'
        /// </summary>
        /// <exception cref="QuadraticEquationException"></exception>
        private void SetA()
        {
            Console.Write("Введите значение a: ");
            var text = Console.ReadLine();
            if (CheckIntValue(text, nameof(A), out int a))
            {
                if (a == default)
                {
                    var ex = new QuadraticEquationException("A - не может быть '0'", Severity.Error);
                    ex.Data[nameof(A)] = A;
                    throw ex;
                }

                A = a;
                AIsSet = true;
                _qudraticEquation = $"Квадратное уравнение = '{A} * x^2 + b * x + c = 0'";
                Console.WriteLine($"Значение '{nameof(A)}' задано, нажмите Enter для продолжения");
            }
        }

        /// <summary>
        /// Задает значение 'B'
        /// </summary>
        private void SetB()
        {
            Console.Write("Введите значение b: ");
            var text = Console.ReadLine();
            if (CheckIntValue(text, nameof(B), out int b))
            {
                B = b;
                BIsSet = true;
                _qudraticEquation = $"Квадратное уравнение = '{A} * x^2 + {B} * x + c = 0'";
                Console.WriteLine($"Значение '{nameof(B)}' задано, нажмите Enter для продолжения");
            }
        }

        /// <summary>
        /// Задает значение 'C'
        /// </summary>
        private void SetC()
        {
            Console.Write("Введите значение c: ");
            var text = Console.ReadLine();
            if (CheckIntValue(text, nameof(C), out int c))
            {
                C = c;
                CIsSet = true;
                _qudraticEquation = $"Квадратное уравнение = '{A} * x^2 + {B} * x + {C} = 0'";
                Console.WriteLine($"Значение '{nameof(C)}' задано, нажмите Enter для продолжения");
            }
        }

        /// <summary>
        /// Расчет квадратного уравнения
        /// </summary>
        /// <returns>Результат решения квадратного уравнения</returns>
        private string Calculate()
        {
            if (B == default && C == default)
            {
                return "x = 0";
            }

            if (B == default)
            {
                double temp = -C / A;

                if (temp >= 0)
                {
                    double x1 = Math.Sqrt(temp);
                    return $"x1 = '{x1}'\t x2 = '{-x1}'";
                }
                else
                {
                    var ex = new QuadraticEquationException("Вещественных значений не найдено", Severity.Warning);
                    ex.Data[nameof(B)] = default;
                    ex.Data["-C / A"] = temp;
                    throw ex;
                }
            }

            if (C == default)
            {
                return $"x1 = '{-B / A}'\t x2 = '0'";
            }

            if (_discriminant == 0)
            {
                return $"x = '{(-B + Math.Sqrt(_discriminant)) / 2 * A}'";
            }
            else if (_discriminant > 0)
            {
                double x1 = (-B + Math.Sqrt(_discriminant)) / 2 * A;
                double x2 = (-B - Math.Sqrt(_discriminant)) / 2 * A;
                return $"x1 = '{x1}'\t x2 = '{x2}'";
            }
            else
            {
                var ex = new QuadraticEquationException("Вещественных значений не найдено", Severity.Warning);
                ex.Data[nameof(_discriminant)] = _discriminant;

                throw ex;
            }
        }

        /// <summary>
        /// Проверка вводимых значений
        /// </summary>
        /// <param name="text">Входящая строка</param>
        /// <param name="message">Сообщение</param>
        /// <param name="intValue">Введенное значение</param>
        /// <returns>True - OK | False - error</returns>
        private bool CheckIntValue(string? text, string message, out int intValue)
        {
            intValue = default;
            if (text == null)
            {
                return false;
            }

            if (int.TryParse(text, out intValue))
            {
                return true;
            }
            else
            {
                try
                {
                    int.Parse(text);
                }
                catch (OverflowException)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Введенное значение '{text}' не вмещается в тип int. От '{int.MinValue}' до '{int.MaxValue}'");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (Exception)
                {
                    var ex = new QuadraticEquationException($"Неверный формат параметра '{message}' = '{text}'", Severity.Error);
                    ex.Data[message] = text;
                    throw ex;
                }

                return false;
            }
        }
    }
}
