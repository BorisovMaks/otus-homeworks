namespace Homework6._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlanetCatalog planetCatalog = new PlanetCatalog();
            planetCatalog.GetPlanet("Earth");
            planetCatalog.GetPlanet("Limonia");
            planetCatalog.GetPlanet("Mars");
            planetCatalog.GetPlanet("Venus");
        }
    }
}
