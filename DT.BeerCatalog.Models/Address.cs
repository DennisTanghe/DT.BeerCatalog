using System.ComponentModel.DataAnnotations;

namespace DT.BeerCatalog.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "De stroate")]
        public string Street { get; set; }

        public int Number { get; set; }

        public string PostalCode { get; set; }

        [Required]
        public string City { get; set; }

        public string Country { get; set; }
    }
}