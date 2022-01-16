using DT.BeerCatalog.Models;

namespace DT.BeerCatalog.FileRepository
{
    public class BeerRepository : IBeerRepository
    {
        // Currently started with in-memmory only
        private List<Beer> _beers = new List<Beer>();

        public Beer AddBeer(Beer beer)
        {
            int newId = 0;
            
            if (_beers.Count > 0) newId = _beers.OrderByDescending(b => b.Id).First().Id;

            newId += 1;

            beer.Id = newId;

            _beers.Add(beer);

            return beer;
        }

        public Beer DeleteBeer(int id)
        {
            Beer? beer = _beers.FirstOrDefault(b => b.Id == id);

            if (beer == null)
            {
                throw new Exception("Beer not found");
            }

            _beers.Remove(beer);

            return beer;
        }

        public List<Beer> GetAllBeers()
        {
            return _beers;
        }

        public Beer GetBeer(int id)
        {
            Beer? beer = _beers.FirstOrDefault(b => b.Id == id);

            if (beer == null)
            {
                throw new Exception("Beer not found");
            }

            return beer;
        }

        public Beer UpdateBeer(Beer beer)
        {
            Beer? beerToUpdate = _beers.FirstOrDefault(b => b.Id == beer.Id);

            if (beerToUpdate == null)
            {
                throw new Exception("Beer not found");
            }

            beerToUpdate.Name = beer.Name;
            beerToUpdate.Colour = beer.Colour;
            beerToUpdate.Brewery = beer.Brewery;
            beerToUpdate.AlcoholPercentage = beer.AlcoholPercentage;

            return beerToUpdate;
        }
    }
}