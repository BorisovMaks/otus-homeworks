namespace Homework6._3
{
    internal class Program
    {
        private static int _counter = default;

        static void Main(string[] args)
        {
            PlanetCatalog planetCatalog = new PlanetCatalog();

            PrintMessage(planetCatalog.GetPlanet("Earth", ValidatePlanet));
            PrintMessage(planetCatalog.GetPlanet("Limonia", ValidatePlanet));
            PrintMessage(planetCatalog.GetPlanet("Mars", ValidatePlanet));
            PrintMessage(planetCatalog.GetPlanet("Venus", ValidatePlanet));

            PrintMessage(planetCatalog.GetPlanet("Earth", (name) => 
            {
                if (name == "Limonia")
                {
                    return "Это запретная планета";
                }
                else
                {
                    return null;
                }
            }));
            PrintMessage(planetCatalog.GetPlanet("Limonia", CheckPlanetName));
            PrintMessage(planetCatalog.GetPlanet("Mars", CheckPlanetName));
            PrintMessage(planetCatalog.GetPlanet("Venus", CheckPlanetName));
        }

        private static void PrintMessage((string name, int orderNumber, double equatorLength, string? error) result)
        {
            if (result.error != null)
            {
                Console.WriteLine(result.error);
            }
            else
            {
                Console.WriteLine(
                    $"Название планеты: {result.name}\n" +
                    $"Порядковый номер от Солнца: {result.orderNumber}\n" +
                    $"Длина экватора: {result.equatorLength}км\n");
            }
        }

        public static string? ValidatePlanet(string name)
        {
            _counter++;

            if (_counter % 3 == 0)
            {
                return $"Вы спрашиваете слишком часто {_counter}\n";
            }

            return null;
        }

        public static string? CheckPlanetName(string name)
        {
            if (name == "Limonia")
            {
                return "Это запретная планета";
            }
            else
            {
                return null;
            }
        }
    }
}
