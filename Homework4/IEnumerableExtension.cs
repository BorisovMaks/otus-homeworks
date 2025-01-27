namespace Homework4
{
    public static class IEnumerableExtension
    {
        /// <summary>
        /// Изменяет порядок элементов последовательности на противоположный.
        /// </summary>
        /// <param name="input">Входная последовательность</param>
        /// <returns>Последовательность, элементы которой соответствуют элементам входной последовательности, но следуют в противоположном порядке.</returns>
        public static IEnumerable<string?> ReverseItems(this IEnumerable<string?> input)
        {
            var output = input.ToList();
            output.Reverse();
            return output;
        }
    }
}
