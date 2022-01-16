using DT.BeerCatalog.Models;

namespace DT.BeerCatalog.FileRepository
{
    public class BreweryRepository : IBreweryRepository
    {
        // Currently started with in-memmory only
        private List<Brewery> _breweries = new List<Brewery>();

        public Brewery AddBrewery(Brewery brewery)
        {
            int newId = 0;
            
            if (_breweries.Count > 0) newId = _breweries.OrderByDescending(b => b.Id).First().Id;

            newId += 1;

            brewery.Id = newId;

            _breweries.Add(brewery);

            return brewery;
        }

        public Brewery DeleteBrewery(int id)
        {
            Brewery? brewery = _breweries.FirstOrDefault(b => b.Id == id);

            if (brewery == null)
            {
                throw new Exception("Brewery not found");
            }

            _breweries.Remove(brewery);

            return brewery;
        }

        public List<Brewery> GetAllBreweries()
        {
            return _breweries;
        }

        public Brewery GetBrewery(int id)
        {
            Brewery? brewery = _breweries.FirstOrDefault(b => b.Id == id);

            if (brewery == null)
            {
                throw new Exception("Brewery not found");
            }

            return brewery;
        }

        public Brewery UpdateBrewery(Brewery brewery)
        {
            Brewery? breweryToUpdate = _breweries.FirstOrDefault(b => b.Id == brewery.Id);

            if (breweryToUpdate == null)
            {
                throw new Exception("Brewery not found");
            }

            breweryToUpdate.Name = brewery.Name;
            breweryToUpdate.Address = brewery.Address;
            breweryToUpdate.About = brewery.About;
            breweryToUpdate.Beers = brewery.Beers;

            return breweryToUpdate;
        }
    }
}