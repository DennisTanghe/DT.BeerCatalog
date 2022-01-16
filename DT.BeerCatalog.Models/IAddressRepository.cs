namespace DT.BeerCatalog.Models
{
    public interface IAddressRepository
    {
        List<Address> GetAllAddresses();

        Address GetAddress(int id);

        Address AddAddress(Address Address);

        Address UpdateAddress(Address Address);

        Address DeleteAddress(int id);
    }
}
