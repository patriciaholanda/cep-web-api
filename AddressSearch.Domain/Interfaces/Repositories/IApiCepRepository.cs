using AddressSearch.Domain.Entities;

namespace AddressSearch.Domain.Interfaces.Repositories;

public interface IApiCepRepository
{
    public Task<Address> GetAddressByCep(string cep);
}