using DT.BeerCatalog.Models;

namespace DT.BeerCatalog.WebApp.Models
{
    public class AddressViewModel
    {
        public AddressViewModel()
        {
            PageTitle = "";
            Addresses = new List<Address>();
            CurrentAddress = new Address();
            ErrorMessage = "";
        }

        public string PageTitle { get; set; }

        public List<Address> Addresses { get; set; }

        public Address CurrentAddress { get; set; }

        public string ErrorMessage { get; set; }
    }
}
