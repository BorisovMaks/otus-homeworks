namespace Homework11
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Take<T>(this IEnumerable<T> collection, int count)
        {
            int received = 0;
            foreach (var item in collection)
            {
                if (received >= count)
                {
                    yield break;
                }
                yield return item;
                received++;
            }
        }

        public static IEnumerable<T> Top<T>(this IEnumerable<T> collection, int percent)
        {
            if (percent < 1 || percent > 100)
            {
                throw new ArgumentException("Значение параметра percent должно быть в диапазоне от 1 до 100");
            }

            var ordered = collection.OrderByDescending(x => x).ToList();
            int count = (int)Math.Ceiling(ordered.Count * percent / 100d);

            return ordered.Take(count);
        }

        public static IEnumerable<T> Top<T, TKey>(this IEnumerable<T> collection, int percent, Func<T, TKey> predicate)
        {
            if (percent < 1 || percent > 100)
            {
                throw new ArgumentException("Значение параметра percent должно быть в диапазоне от 1 до 100");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException("Условие сортировки не может быть null");
            }

            var ordered = collection.OrderByDescending(predicate).ToList();
            int count = (int)Math.Ceiling(ordered.Count * percent / 100d);

            return ordered.Take(count);
        }
    }
}
