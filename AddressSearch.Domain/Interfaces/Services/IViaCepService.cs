using AddressSearch.Domain.Entities;

namespace AddressSearch.Domain.Interfaces.Services;

public interface IViaCepService
{
    public Task<Address> GetAddressByCep(string cep);
    public Task<List<Address>> GetAddressByStreet(string state, string city, string street);
}