using System.Collections.Concurrent;
using System.Net.Mail;
using System.Threading;

namespace Homework10._2
{
    internal class Librarian : IDisposable, ILibrarian
    {
        private ConcurrentDictionary<string, int> _books = new();
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();
        private bool disposedValue;

        public Librarian()
        {
            Thread thread = new(new ParameterizedThreadStart(Percent));
            thread.Start(_cts.Token);
        }

        private void Percent(object? token)
        {
            if (token is not CancellationToken cancellationToken)
            {
                return;
            }

            while (!cancellationToken.IsCancellationRequested)
            {
                Thread.Sleep(1000);

                foreach (var bookData in _books) 
                {
                    if (bookData.Value >= 100)
                    {
                        if (!_books.TryRemove(bookData))
                        {
                            Console.WriteLine($"Ошибка удаления книги {bookData.Key}");
                        }
                    }
                    else
                    {
                        if(!_books.TryUpdate(bookData.Key, bookData.Value + 1, bookData.Value))
                        {
                            Console.WriteLine($"Ошибка обновления книги {bookData.Key}");
                        }
                    }
                }
            }
        }

        public void ListOfBooks()
        {
            Console.WriteLine("Список книг:");
            foreach (var book in _books)
            {
                Console.WriteLine($"{book.Key} - {book.Value}");
            }
        }

        public void AddBook()
        {
            Console.WriteLine("Введите название книги");
            var book = Console.ReadLine();

            if (book == null)
            {
                return;
            }

            if (!_books.TryAdd(book.ToLower(), 0))
            {
                Console.WriteLine("Книга с таким названием уже была добавлена ранее");
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _cts.Cancel();
                    _cts.Dispose();
                }

                disposedValue = true;
            }
        }

        ~Librarian()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
