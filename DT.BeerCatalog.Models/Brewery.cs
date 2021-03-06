namespace DT.BeerCatalog.Models
{
    public class Brewery
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string About { get; set; }

        public Address Address { get; set; }

        public List<Beer> Beers { get; set; }

        public Brewery()
        {
            Name = "";
            About = "";
            Address = new();
            Beers = new();
        }
    }
}