namespace Homework6._3
{
    public class PlanetCatalog
    {
        private int _counter = default;
        private string? planetFound = null;
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

        public (string name, int orderNumber, double equatorLength, string? error) GetPlanet(string planetName, Func<string, string?> func)
        {
            var validationResult = func?.Invoke(planetName);

            if (validationResult != null)
            {
                return (planetName, 0, 0d, validationResult);
            }

            foreach (var planet in planets)
            {
                if (planet.Name.ToLower() == planetName.ToLower())
                {
                    return (planetName, planet.OrderNumber, planet.EquatorLength, null);
                }
            }

            return (planetName, 0, 0d, "Планета в коллекции не найдена");
        }
    }
}
