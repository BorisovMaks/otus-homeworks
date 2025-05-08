using System.Text;

namespace Homework8
{
    internal class Program
    {
        static void Main()
        {
            List<DirectoryInfo> directoryInfoList = [];
            directoryInfoList.Add(CreateDirectory(@"C:\Otus\TestDir1"));
            directoryInfoList.Add(CreateDirectory(@"C:\Otus\TestDir2"));

            foreach (DirectoryInfo directoryInfo in directoryInfoList)
            {
                Console.WriteLine($"Директория {directoryInfo.Name} создана");
                CreateFiles(directoryInfo, 10);
                Console.WriteLine($"Файлы в директории {directoryInfo.Name} созданы");
                Console.WriteLine($"Запись данных в файлы директории {directoryInfo.Name}");
                WriteFiles(directoryInfo);
                Console.WriteLine($"Добавление данных в файлы директории {directoryInfo.Name}");
                AddDataToFiles(directoryInfo);
            }
            foreach (DirectoryInfo directoryInfo in directoryInfoList)
            {
                Console.WriteLine($"Чтение файлов из директории {directoryInfo.Name}");
                ReadToPrintFiles(directoryInfo);
            }
        }

        static DirectoryInfo CreateDirectory(string path)
        {
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                if (!directoryInfo.Exists)
                {
                    directoryInfo.Create();
                }
                return directoryInfo;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка создания директории: {ex.GetType().Name} - {ex.Message}");
                throw;
            }
        }

        static void CreateFiles(DirectoryInfo directoryInfo, int countFiles)
        {
            string fileName;
            try
            {
                for (int i = 1; i <= countFiles; i++)
                {
                    fileName = directoryInfo.FullName + @"\File" + i + ".txt";
                    if(!File.Exists(fileName))
                    {
                        File.Create(fileName).Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка создания файла: {ex.GetType().Name} - {ex.Message}");
                throw;
            }
        }

        static void WriteFiles(DirectoryInfo directoryInfo)
        {
            FileInfo[] filesInfo = CheckDirectory(directoryInfo);

            try
            {
                foreach (var file in filesInfo)
                {
                    using (var fileStream = File.OpenWrite(file.FullName))
                    {
                        byte[] data = new UTF8Encoding(true).GetBytes(file.Name);
                        fileStream.Write(data, 0, data.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка записи в файл: {ex.GetType().Name} - {ex.Message}");
                throw;
            }
        }

        static void AddDataToFiles(DirectoryInfo directoryInfo)
        {
            FileInfo[] filesInfo = CheckDirectory(directoryInfo);

            try
            {
                foreach (var file in filesInfo)
                {
                    using (var fileStream = File.OpenWrite(file.FullName))
                    {
                        byte[] data = new UTF8Encoding(true).GetBytes(" " + DateTime.Now.ToString());
                        fileStream.Seek(0, SeekOrigin.End);
                        fileStream.Write(data, 0, data.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка добавления данных в файл: {ex.GetType().Name} - {ex.Message}");
                throw;
            }
        }

        private static FileInfo[] CheckDirectory(DirectoryInfo directoryInfo)
        {
            FileInfo[] filesInfo = directoryInfo.GetFiles();
            if (filesInfo.Length == 0)
            {
                Console.WriteLine("В директории нет файлов");
            }
            return filesInfo;
        }

        static void ReadToPrintFiles(DirectoryInfo directoryInfo)
        {
            FileInfo[] filesInfo = CheckDirectory(directoryInfo);

            try
            {
                StreamReader streamReader;
                foreach (var fileInfo in filesInfo)
                {
                    using (streamReader = fileInfo.OpenText())
                    {
                        Console.WriteLine($"{fileInfo.Name} : {streamReader.ReadToEnd()}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка чтения файла: {ex.GetType().Name} - {ex.Message}");
                throw;
            }
        }
    }
}
