namespace DT.BeerCatalog.Models
{
    public class Beer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Brewery Brewery { get; set; }

        public BeerColour Colour { get; set; }

        public double AlcoholPercentage { get; set; }

    }
}