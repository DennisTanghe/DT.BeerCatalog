using DT.BeerCatalog.Models;
using System.Text.Json;

namespace DT.BeerCatalog.FileRepository
{
    public class BreweryRepository : IBreweryRepository
    {
        private List<Brewery> _breweries = new List<Brewery>();
        private bool _breweryListIsEmpty = false;

        public Brewery AddBrewery(Brewery brewery)
        {
            int newId = 0;
            
            if (_breweries.Count > 0) newId = _breweries.OrderByDescending(b => b.Id).First().Id;

            newId += 1;

            brewery.Id = newId;

            SaveBreweryToFile(brewery);

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

            DeleteBreweryFile(id);

            _breweries.Remove(brewery);

            return brewery;
        }

        public List<Brewery> GetAllBreweries()
        {
            if (_breweries.Count == 0 && !_breweryListIsEmpty)
            {
                LoadAllBreweries();
            }

            return _breweries;
        }

        public Brewery GetBrewery(int id)
        {
            if (_breweries.Count == 0 && !_breweryListIsEmpty)
            {
                LoadAllBreweries();
            }

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

            SaveBreweryToFile(brewery);

            return breweryToUpdate;
        }

        private void LoadAllBreweries()
        {
            string[] breweryFiles = Directory.GetFiles("D:\\Source\\DT.BeerCatalog\\Data\\Breweries");
            bool breweryFound = false;

            foreach (string file in breweryFiles)
            {
                string json = File.ReadAllText(file);

                Brewery? brewery = JsonSerializer.Deserialize<Brewery>(json);

                if (brewery != null)
                {
                    _breweries.Add(brewery);
                    breweryFound = true;
                }
            }

            if (!breweryFound) _breweryListIsEmpty = true;
        }

        private void SaveBreweryToFile(Brewery brewery)
        {
            string json = JsonSerializer.Serialize(brewery);

            File.WriteAllText($"D:\\Source\\DT.BeerCatalog\\Data\\Breweries\\{brewery.Id}.json", json);

            _breweryListIsEmpty = false;
        }

        private void DeleteBreweryFile(int id)
        {
            string filePath = $"D:\\Source\\DT.BeerCatalog\\Data\\Breweries\\{id}.json";

            File.Delete(filePath);
        }
    }
}