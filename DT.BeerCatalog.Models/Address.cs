using System.ComponentModel.DataAnnotations;

namespace DT.BeerCatalog.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The street is required")]
        [Display(Name = "Street")]
        public string Street { get; set; }

        [Required(ErrorMessage = "The number is required")]
        [Display(Name = "Number")]
        public int Number { get; set; }

        [Required(ErrorMessage = "The postal code is required")]
        [Display(Name = "Postal code")]
        public string PostalCode { get; set; }


        [Required(ErrorMessage = "The city is required")]
        [Display(Name = "City")]
        public string City { get; set; }


        [Required(ErrorMessage = "The country is required")]
        [Display(Name = "Country")]
        public string Country { get; set; }

        public Address()
        {
            Street = "";
            PostalCode = "";
            City = "";
            Country = "";
        }
    }
}