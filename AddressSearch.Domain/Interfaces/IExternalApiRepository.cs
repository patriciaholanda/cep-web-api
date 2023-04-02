using AddressSearch.Domain.Entities;

namespace AddressSearch.Domain.Interfaces
{
    public interface IExternalApiRepository
    {
        public Task<Address> GetAddressByCep(string cep);

        public Task<List<Address>> GetAddressByStreet(string state, string city, string street);
    }
}