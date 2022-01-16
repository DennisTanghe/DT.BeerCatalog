namespace DT.BeerCatalog.Models
{
    public interface IBreweryRepository
    {
        List<Brewery> GetAllBreweries();

        Brewery GetBrewery(int id);

        Brewery AddBrewery(Brewery brewery);

        Brewery UpdateBrewery(Brewery brewery);

        Brewery DeleteBrewery(int id);
    }
}
