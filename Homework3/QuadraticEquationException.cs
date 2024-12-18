using System.Collections;
using System.Text;

namespace Homework3
{
    public class QuadraticEquationException : Exception
    {
        private readonly int _underScoreCount = 50;
        private readonly char _underScore = '_';
        public Severity Severity { get; private set; }
        public ConsoleColor BackgroundColor { get; private set; }
        public ConsoleColor ForegroundColor { get; private set; }

        public QuadraticEquationException(
            string message,
            Severity severity = Severity.Default
            ) : base(message)
        {
            Severity = severity;
            CalculateColors();
        }

        /// <summary>
        /// Вывод данных об ошибке
        /// </summary>
        /// Можно конечно и так сделать -> FormatData(string message, Severity severity, IDictionary data)
        /// <returns>Итоговая строка</returns>
        public string FormatData()
        {
            var underScore = WriteUnderScore();

            StringBuilder sb = new();
            sb.AppendLine(underScore);
            sb.AppendLine(Message);
            sb.AppendLine(underScore);

            foreach (var exception in Data)
            {
                if (exception is DictionaryEntry entry)
                {
                    sb.AppendLine($"'{entry.Key}' = '{entry.Value}'");
                }
                else
                {
                    sb.AppendLine(exception.ToString());
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Задает цвет вывода ошибки
        /// </summary>
        private void CalculateColors()
        {
            switch (Severity)
            {
                case Severity.Default:
                {
                    BackgroundColor = ConsoleColor.Black;
                    ForegroundColor = ConsoleColor.White;
                    break;
                }
                case Severity.Warning:
                {
                    BackgroundColor = ConsoleColor.Yellow;
                    ForegroundColor = ConsoleColor.Black;
                    break;
                }
                case Severity.Error:
                {
                    BackgroundColor = ConsoleColor.Red;
                    ForegroundColor = ConsoleColor.White;
                    break;
                }
            }
        }

        /// <summary>
        /// Создание разделительной линии
        /// </summary>
        /// <returns>Итоговая строка</returns>
        private string WriteUnderScore()
        {
            StringBuilder sb = new();
            for (int i = 0; i < _underScoreCount; i++)
            {
                sb.Append(_underScore);
            }

            return sb.ToString();
        }
    }
}
