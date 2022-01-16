using DT.BeerCatalog.Models;

namespace DT.BeerCatalog.WebApp.Models
{
    public class AddressViewModel
    {
        public string PageTitle { get; set; }

        public List<Address> Addresses { get; set; }

        public Address CurrentAddress { get; set; }
    }
}
