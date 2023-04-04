using AddressSearch.Domain.Entities;

namespace AddressSearch.Domain.Interfaces.Services;

public interface IAwesomeApiCepService
{
    public Task<Address> GetAddressByCep(string cep);
}