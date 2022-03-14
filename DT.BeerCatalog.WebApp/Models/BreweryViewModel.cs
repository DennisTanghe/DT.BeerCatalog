using DT.BeerCatalog.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DT.BeerCatalog.WebApp.Models
{
    public class BreweryViewModel
    {
        public BreweryViewModel()
        {
            PageTitle = "";
            Action = "";
            SubmitButtonLabel = "";
            Breweries = new List<Brewery>();
            CurrentBrewery = new Brewery();
            AddressList = new List<SelectListItem>();
            ErrorMessage = "";
        }

        public string PageTitle { get; set; }

        public string Action { get; set; }

        public string SubmitButtonLabel { get; set; }

        public List<Brewery> Breweries { get; set; }

        public Brewery CurrentBrewery { get; set; }

        public int SelectedAddressId { get; set; }

        public List<SelectListItem> AddressList { get; set; }

        public string ErrorMessage { get; set; }
    }
}
