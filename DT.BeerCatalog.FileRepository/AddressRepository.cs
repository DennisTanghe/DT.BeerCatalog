using DT.BeerCatalog.Models;
using System.Text.Json;

namespace DT.BeerCatalog.FileRepository
{
    public class AddressRepository : IAddressRepository
    {
        private List<Address> _addresses = new List<Address>();
        private bool _addressListIsEmpty = false;

        public Address AddAddress(Address address)
        {
            int newId = 0;
            
            if (_addresses.Count > 0) newId = _addresses.OrderByDescending(b => b.Id).First().Id;

            newId += 1;

            address.Id = newId;

            SaveAddressToFile(address);

            _addresses.Add(address);

            return address;
        }

        public Address DeleteAddress(int id)
        {
            Address? address = _addresses.FirstOrDefault(b => b.Id == id);

            if (address == null)
            {
                throw new Exception("Address not found");
            }

            DeleteAddressFile(id);

            _addresses.Remove(address);

            return address;
        }

        public List<Address> GetAllAddresses()
        {
            if (_addresses.Count == 0 && !_addressListIsEmpty)
            {
                LoadAllAddresses();
            }

            return _addresses;
        }

        public Address GetAddress(int id)
        {
            if (_addresses.Count == 0 && !_addressListIsEmpty)
            {
                LoadAllAddresses();
            }

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

            SaveAddressToFile(address);

            return addressToUpdate;
        }

        private void LoadAllAddresses()
        {
            string[] addressFiles = Directory.GetFiles("D:\\Source\\DT.BeerCatalog\\Data\\Addresses");
            bool addressFound = false;

            foreach(string file in addressFiles)
            {
                string json = File.ReadAllText(file);

                Address? address = JsonSerializer.Deserialize<Address>(json);

                if (address != null)
                {
                    _addresses.Add(address);
                    addressFound = true;
                }
            }

            if (!addressFound) _addressListIsEmpty = true;
        }

        private void SaveAddressToFile(Address address)
        {
            string json = JsonSerializer.Serialize(address);

            File.WriteAllText($"D:\\Source\\DT.BeerCatalog\\Data\\{address.Id}.json", json);

            _addressListIsEmpty = false;
        }

        private void DeleteAddressFile(int id)
        {
            string filePath = $"D:\\Source\\DT.BeerCatalog\\Data\\{id}.json";

            File.Delete(filePath);
        }
    }
}