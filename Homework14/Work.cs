
using Homework14.Repositories;

namespace Homework14
{
    public class Work
    {
        internal async Task Start()
        {
            await Task.Factory.StartNew(async () =>
            {
                await Customers();
                await Orders();
                await Products();
            });
        }

        private async Task Products()
        {
            Console.WriteLine("\t-----Products-----");
            var productRepository = new ProductRepository();
            var products = await productRepository.GetAllAsync();
            products.ForEach(Console.WriteLine);

            var product = await productRepository.GetById(1);
            if (product != null)
            {
                Console.WriteLine($"\n{product}\n");
            }
        }

        private async Task Orders()
        {
            Console.WriteLine("\t-----Orders-----");
            var orderRepository = new OrderRepository();
            var orders = await orderRepository.GetAllAsync();
            orders.ForEach(Console.WriteLine);

            var order = await orderRepository.GetById(1);
            if (order != null)
            {
                Console.WriteLine($"\n{order}\n");
            }
        }

        private async Task Customers()
        {
            Console.WriteLine("\t-----Customers-----");
            var customerRepository = new CustomerRepository();
            var customers = await customerRepository.GetAllAsync();
            customers.ForEach(Console.WriteLine);

            var customer = await customerRepository.GetById(1);
            if (customer != null)
            {
                Console.WriteLine($"\n{customer}\n");
            }
        }
    }
}
