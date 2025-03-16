namespace Homework6._2
{
    public class PlanetCatalog
    {
        private int _counter = default;
        private string planetFound = string.Empty;

        List<Planet> planets = [];

        public PlanetCatalog()
        {
            Planet venus = new("Venus", 2, 38025, previousPlanet: null);
            planets.Add(venus);
            Planet earth = new("Earth", 3, 40075, venus);
            planets.Add(earth);
            Planet mars = new("Mars", 4, 21344, earth);
            planets.Add(mars);
        }

        /// <summary>
        /// Получить информацию о планете 
        /// </summary>
        /// <param name="namePlanet">Входящая строка</param>
        /// <returns>Кортеж с информацией о планете</returns>
        public (int orderNumber, double equatorLength, string error) GetPlanet(string namePlanet)
        {
            if (_counter >= 2)
            {
                _counter = 0;
                Console.WriteLine("Вы спрашиваете слишком часто\n");
                return (0, 0, "Вы спрашиваете слишком часто");
            }

            var currentPlanet = (0, 0d, string.Empty);

            foreach (var planet in planets)
            {
                if (planet.Name == namePlanet)
                {
                    currentPlanet = (planet.OrderNumber, planet.EquatorLength, string.Empty);
                    _counter++;
                    Console.WriteLine($"Название планеты: {planet.Name}\n" +
                                      $"Порядковый номер от Солнца: {planet.OrderNumber}\n" +
                                      $"Длина экватора: {planet.EquatorLength}км\n");
                    return currentPlanet;
                }
                else
                {
                    planetFound = "Не удалось найти планету\n";
                    currentPlanet = (0, 0, "Не удалось найти планету");
                }
            }
            _counter++;
            Console.WriteLine(planetFound);

            return currentPlanet;
        }
    }
}
