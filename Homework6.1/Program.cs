using System.Text;

namespace Homework6._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            object? v = null;
            var venus = new
            {
                Name = "Venus",
                OrderNumber = 2,
                EquatorLength = 38025,
                PreviousPlanet = v,
            };
            var earth = new
            {
                Name = "Earth",
                OrderNumber = 3,
                EquatorLength = 40075,
                PreviousPlanet = venus,
            };
            var mars = new
            {
                Name = "Mars",
                OrderNumber = 4,
                EquatorLength = 21344,
                PreviousPlanet = earth,
            };
            var venus2 = new
            {
                Name = "Venus",
                OrderNumber = 2,
                EquatorLength = 38025,
                PreviousPlanet = mars,
            };

            PrintPlanet(venus, venus);
            PrintPlanet(earth, venus);
            PrintPlanet(mars, venus);
            PrintPlanet(venus2, venus);
        }

        /// <summary>
        /// Вывод на планеты консоль и сравнение ее с Венерой
        /// </summary>
        /// <param name="planetCompare">Планета для сравнения</param>
        /// <param name="Venus">Венера</param>
        public static void PrintPlanet(dynamic planetCompare, dynamic Venus)
        {            
            string isEqual = planetCompare.Equals(Venus) ? "Равны" : "Не равны";

            var sb = new StringBuilder();
            sb.Append($"Name: {planetCompare.Name}\n");
            sb.Append($"OrderNumber: {planetCompare.OrderNumber}\n");
            sb.Append($"EquatorLength: {planetCompare.EquatorLength}км\n");
            sb.Append($"PreviousPlanet: {planetCompare.PreviousPlanet}\n");
            sb.Append($"isEqualtoVenus: {isEqual}\n");
            sb.ToString();

            Console.WriteLine(sb);
        }
    }
}
