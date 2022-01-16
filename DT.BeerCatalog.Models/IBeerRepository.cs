namespace DT.BeerCatalog.Models
{
    public interface IBeerRepository
    {
        List<Beer> GetAllBeers();

        Beer GetBeer(int id);

        Beer AddBeer(Beer beer);

        Beer UpdateBeer(Beer beer);

        Beer DeleteBeer(int id);
    }
}
