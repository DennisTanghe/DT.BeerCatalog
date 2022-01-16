using DT.BeerCatalog.Models;

namespace DT.BeerCatalog.FileRepository
{
    public class AddressRepository : IAddressRepository
    {
        // Currently started with in-memmory only
        private List<Address> _addresses = new List<Address>();

        public Address AddAddress(Address Address)
        {
            int newId = 0;
            
            if (_addresses.Count > 0) newId = _addresses.OrderByDescending(b => b.Id).First().Id;

            newId += 1;

            Address.Id = newId;

            _addresses.Add(Address);

            return Address;
        }

        public Address DeleteAddress(int id)
        {
            Address? address = _addresses.FirstOrDefault(b => b.Id == id);

            if (address == null)
            {
                throw new Exception("Address not found");
            }

            _addresses.Remove(address);

            return address;
        }

        public List<Address> GetAllAddresses()
        {
            return _addresses;
        }

        public Address GetAddress(int id)
        {
            Address? address = _addresses.FirstOrDefault(b => b.Id == id);

            if (address == null)
            {
                throw new Exception("Address not found");
            }

            return address;
        }

        public Address UpdateAddress(Address address)
        {
            Address? addressToUpdate = _addresses.FirstOrDefault(b => b.Id == address.Id);

            if (addressToUpdate == null)
            {
                throw new Exception("Address not found");
            }

            addressToUpdate.Street = address.Street;
            addressToUpdate.Number = address.Number;
            addressToUpdate.PostalCode = address.PostalCode;
            addressToUpdate.City = address.City;
            addressToUpdate.Country = address.Country;

            return addressToUpdate;
        }
    }
}