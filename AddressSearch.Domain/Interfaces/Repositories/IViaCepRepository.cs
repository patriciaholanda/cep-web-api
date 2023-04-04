using AddressSearch.Domain.Entities;

namespace AddressSearch.Domain.Interfaces.Repositories
{
    public interface IViaCepRepository
    {
        public Task<Address> GetAddressByCep(string cep);
        public Task<List<Address>> GetAddressByStreet(string state, string city, string street);
    }
}