using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DT.BeerCatalog.Models
{
    public class Brewery
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string About { get; set; }

        [ValidateNever] // validate when new, don't validate when existing => how?
        public Address Address { get; set; }

        public List<Beer> Beers { get; set; }
    }
}