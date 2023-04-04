using AddressSearch.Domain.Entities;

namespace AddressSearch.Domain.Interfaces.Repositories;

public interface IAwesomeApiCepRepository
{
    public Task<Address> GetAddressByCep(string cep);
}