using System;
using System.Collections.Specialized;

namespace Homework10._1
{
    internal class Customer
    {
        public void OnItemChanged(
            object? sender,
            NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        if (e.NewItems == null)
                        {
                            return;
                        }

                        foreach (var p in e.NewItems)
                        {
                            Console.WriteLine($"Добавлен товар: {p}");
                        }
                        break;
                    }
                case NotifyCollectionChangedAction.Remove:
                    {
                        if (e.OldItems == null)
                        {
                            return;
                        }

                        foreach (var p in e.OldItems)
                        {
                            Console.WriteLine($"Удален товар: {p}");
                        }
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
