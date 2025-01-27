namespace Homework4
{
    public class TryPopStackException : Exception
    {
        public TryPopStackException(string message) : base(message) 
        {
            Console.WriteLine(message);
        }
    }
}
