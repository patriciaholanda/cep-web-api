using AddressSearch.Domain.Entities;

namespace AddressSearch.Domain.Interfaces.Services;

public interface IApiCepService
{
    public Task<Address> GetAddressByCep(string cep);
}