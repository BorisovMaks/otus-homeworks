using Homework14.Repositories;
using System.Threading.Tasks;

namespace Homework14
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Work work = new();
            await work.Start();

            Console.ReadLine();
        }
    }
}
