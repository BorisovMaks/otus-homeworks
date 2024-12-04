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
        private readonly string _menuString = $"Список доступных команд:\n /help\n /info\n /echo\n /addtask\n /showtasks\n /removetask\n /exit\n ";
        private readonly string _currentBotData = "Версия программы v1.0 дата создания 24.11.2024";
        private List<string?> _tasks = new ();
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
            if (!TextIsValid(line))
            {
                WriteLine($"'{_currentUserName}' - {_menuString}");
                return;
            }

            if (line.StartsWith("/echo") &&
                TextIsValid(_currentUserName))
            {
                ProcessEcho(line);
                return;
            }

            switch (line)
            {
                case "/start":
                    {
                        bool result = ProcessStart();
                        while (!result)
                        {
                            result = ProcessStart();
                        }

                        if (!TextIsValid(_currentUserName))
                        {
                            WriteLine($"Добро пожаловать!");
                            WriteLine(_startMessage);
                        }

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
                case "/addtask":
                    {
                        ProcessAddTask();
                        break;
                    }
                case "/showtasks":
                    {
                        ProcessShowTasks();
                        break;
                    }
                case "/removetask":
                    {
                        bool result = ProcessRemoveTask();
                        while (!result)
                        {
                            result = ProcessRemoveTask();
                        }
                        WriteLine($"'{_currentUserName}' - {_menuString}");
                       
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
        /// <returns>True - OK | False - error</returns>
        private bool ProcessStart()
        {
            if (!TextIsValid(_currentUserName))
            {
                WriteLine("Введите своё имя. Для отмены введите '/exit'");

                var name = Console.ReadLine();

                if (name == "/exit")
                {
                    return true;
                }

                if (TextIsValid(name))
                {
                    _currentUserName = name;
                    WriteLine($"Привет '{_currentUserName}'");
                }
                else
                {
                    return false;
                }
            }
            else
            {
                WriteLine($"Добро пожаловать!");
                WriteLine(_startMessage);
                return false;
            }
            
            WriteLine($"'{_currentUserName}' - {_menuString}");
            return true;
        }

        /// <summary>
        /// Обработка команды 'Info'
        /// </summary>
        private void ProcessInfo()
        {
            if (!TextIsValid(_currentUserName))
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
            StringBuilder builder = new();
            builder.AppendLine("Команда /start позволяет ввести имя пользователя, а так же предоставляет доступ к команде /echo ");
            builder.AppendLine("Команда /help отображает краткую справочную информацию о том, как пользоваться программой");
            builder.AppendLine("Команда /info предоставляет информацию о версии программы и дате её создания.");
            builder.AppendLine("Команда /echo при вводе её с аргументом, возвращает введенный текст");
            builder.AppendLine("Команда /addtask добавить новую задачу в список");
            builder.AppendLine("Команда /showtasks отобразить список задач");
            builder.AppendLine("Команда /removetask удалить задачу из списка");
            builder.AppendLine("Команда /exit завершает работу программы");

            if (TextIsValid(_currentUserName))
            {
                WriteLine($"'{_currentUserName}' - {builder.ToString()}");
                WriteLine($"'{_currentUserName}' - {_menuString}");
            }
            else
            {
                WriteLine($"{builder.ToString()}");
                WriteLine($"{_startMessage}");
            }
        }

        /// <summary>
        /// Обработка команды 'AddTask'
        /// </summary>
        private void ProcessAddTask()
        {
            if (TextIsValid(_currentUserName))
            {
                WriteLine("Введите описание задачи");
                var task = Console.ReadLine();

                if (TextIsValid(task))
                {
                    _tasks.Add(task);
                    WriteLine($"Задача '{task}' добавлена");
                    WriteLine($"'{_currentUserName}' - {_menuString}");
                }
            }
            else
            {
                WriteLine($"Добро пожаловать!");
                WriteLine(_startMessage);
            }
        }

        /// <summary>
        /// Обработка команды 'ShowTasks'
        /// </summary>
        private void ProcessShowTasks()
        {
            if (TextIsValid(_currentUserName))
            {
                if (_tasks.Any())
                {
                    StringBuilder sb = new();
                    foreach (var task in _tasks)
                    {
                        sb.AppendLine(task);
                    }
                    WriteLine(sb.ToString());
                }
                else
                {
                    WriteLine("Список пуст");
                }
            }
            else
            {
                WriteLine($"Добро пожаловать!");
                WriteLine(_startMessage);
            }
        }

        /// <summary>
        /// Обработка команды 'RemoveTask'
        /// </summary>
        /// <returns>True - OK | False - error</returns>
        private bool ProcessRemoveTask()
        {
            if (TextIsValid(_currentUserName))
            {
                if (_tasks.Any())
                {
                    PrintTaskList();

                    WriteLine("Введите номер задачи для удаления. Для отмены введите '/exit'");
                    var taskToRemove = Console.ReadLine();

                    if (!TextIsValid(taskToRemove))
                    {
                        WriteLine("Задачи под таким номером не найдено");
                        WriteLine("Введите номер задачи для удаления");
                        return false;
                    }

                    if (taskToRemove == "/exit")
                    {
                        return true;
                    }

                    if (int.TryParse(taskToRemove, out var number))
                    {
                        if (_tasks.ElementAtOrDefault(number - 1) != null)
                        {
                            _tasks.RemoveAt(number - 1);
                            WriteLine($"Задача с номером '{number}' удалена");
                        }
                        else
                        {
                            WriteLine("Задачи под таким номером не найдено");
                            WriteLine("Введите номер задачи для удаления");
                            return false;
                        }
                    }
                    else
                    {
                        WriteLine("Необходимо ввести номер задачи!!!");
                    }
                }
                else
                {
                    WriteLine("Список пуст");
                }
            }
            else
            {
                WriteLine($"Добро пожаловать!");
                WriteLine(_startMessage);
            }
            return true;
        }

        /// <summary>
        /// Выводит список задач в консоль
        /// </summary>
        private void PrintTaskList()
        {
            StringBuilder sb = new();
            foreach (var task in _tasks)
            {
                sb.AppendLine($"{_tasks.IndexOf(task) + 1} - {task}");
            }

            WriteLine(sb.ToString());
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
        /// Обработка команды 'Exit'
        /// </summary>
        private void ProcessExit()
        {
            WriteLine("Выход");
            Console.ReadLine();
            _currentUserName = string.Empty;
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
        /// <returns>True - OK | False - error</returns>
        private static bool TextIsValid(string? line)
        {
            return
                !string.IsNullOrEmpty(line) ||
                !string.IsNullOrWhiteSpace(line);
        }

        /// <summary>
        /// Получение текущей версии ПО
        /// </summary>
        /// <returns>Версия и дата создания программы</returns>
        private string GetCurrentVersion()
        {
            return _currentBotData;
        }
    }
}
