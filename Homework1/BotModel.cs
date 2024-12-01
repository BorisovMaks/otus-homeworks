using System.Text;

namespace Homework1
{
    /// <summary>
    /// Модель телеграмм бота
    /// </summary>
    public class BotModel
    {
        private string? _currentUserName = string.Empty;
        private readonly string _startMessage = $"Список доступных команд:\n /start\n /help\n /info\n /exit\n";
        private readonly string _menuString = $"Список доступных команд:\n /help\n /info\n /echo\n /exit\n ";
        private readonly string _currentBotData = "Версия программы v1.0 дата создания 24.11.2024";

        public BotModel()
        {
             
        }

        /// <summary>
        /// Запуск работы бота
        /// </summary>
        public void Start()
        {
            WriteLine($"Добро пожаловать!");
            WriteLine(_startMessage);

            var line = Console
                .ReadLine()?
                .ToLower();

            while (line != "/exit")
            {
                Process(
                    line == null 
                        ? string.Empty 
                        : line);

                line = Console
                    .ReadLine()?
                    .ToLower();
            }

            ProcessExit();
            return;
        }

        private void Process(string line)
        {
            if (ValidateString(line))
            {
                WriteLine($"'{_currentUserName}' - {_menuString}");
                return;
            }

            if (line.StartsWith("/echo") &&
                !ValidateString(_currentUserName))
            {
                ProcessEcho(line);
                return;
            }

            switch (line)
            {
                case "/start":
                {
                    ProcessStart();
                    break;
                }
                case "/help":
                {
                    ProcessHelp();
                    break;
                }
                case "/info":
                {
                    ProcessInfo();
                    break;
                }
                default:
                {
                    WriteLine($"Добро пожаловать!");
                    WriteLine(_startMessage);
                    break;
                }
            }
        }

        /// <summary>
        /// Обработка команды 'Start'
        /// </summary>
        private void ProcessStart()
        {
            if (ValidateString(_currentUserName))
            {
                WriteLine("Введите своё имя");

                var name = Console.ReadLine();

                if (!ValidateString(name))
                {
                    _currentUserName = name;
                    WriteLine($"Привет '{_currentUserName}'");
                }
            }
            else
            {
                WriteLine($"Добро пожаловать!");
                WriteLine(_startMessage);
            }

            WriteLine($"'{_currentUserName}' - {_menuString}");
        }

        /// <summary>
        /// Обработка команды 'Info'
        /// </summary>
        private void ProcessInfo()
        {
            if (ValidateString(_currentUserName))
            {
                WriteLine($"{GetCurrentVersion()}");
                WriteLine($"{_menuString}");
            }
            else
            {
                WriteLine($"'{_currentUserName}' - {GetCurrentVersion()}");
                WriteLine($"'{_currentUserName}' - {_menuString}");
            }
        }

        /// <summary>
        /// Обработка команды 'Help'
        /// </summary>
        private void ProcessHelp()
        {
            StringBuilder builder = new ();
            builder.AppendLine("Команда /start позволяет ввести имя пользователя, а так же предоставляет доступ к команде /echo ");
            builder.AppendLine("Команда /help отображает краткую справочную информацию о том, как пользоваться программой");
            builder.AppendLine("Команда /info предоставляет информацию о версии программы и дате её создания.");
            builder.AppendLine("Команда /echo при вводе её с аргументом, возвращает введенный текст");
            builder.AppendLine("Команда /exit завершает работу программы");
            WriteLine($"'{_currentUserName}' - {builder.ToString()}");
            WriteLine($"'{_currentUserName}' - {_menuString}");
        }

        /// <summary>
        /// Обработка команды 'Exit'
        /// </summary>
        private void ProcessExit()
        {
            WriteLine("Выход");
            Console.ReadLine();
            _currentUserName = string.Empty;
        }

        /// <summary>
        /// Обработка команды 'Echo'
        /// </summary>
        /// <param name="line">Команда</param>
        private void ProcessEcho(string line)
        {
            WriteLine(line.Substring(5));
            WriteLine($"'{_currentUserName}' -  {_menuString}");
        }

        /// <summary>
        /// Напечатать строку
        /// </summary>
        /// <param name="text">Текст</param>
        private void WriteLine(string text)
        {
            Console.WriteLine();
            Console.WriteLine(text);
        }

        /// <summary>
        /// Проверка вводимых данных
        /// </summary>
        /// <param name="line">входящая строка</param>
        /// <returns>true - Ok | false - error</returns>
        private static bool ValidateString(string? line)
        {
            return
                string.IsNullOrEmpty(line) ||
                string.IsNullOrWhiteSpace(line);
        }

        /// <summary>
        /// Получение текущей версии ПО
        /// </summary>
        private string GetCurrentVersion()
        {
            return _currentBotData;
        }
    }
}
