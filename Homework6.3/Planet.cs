namespace Homework6._3
{
    internal class Planet(string name, int orderNumber, double equatorLength, Planet? previousPlanet)
    {
        public string Name { get; set; } = name;
        public int OrderNumber { get; set; } = orderNumber;
        public double EquatorLength { get; set; } = equatorLength;
        public Planet? PreviousPlanet { get; set; } = previousPlanet;
    }
}
