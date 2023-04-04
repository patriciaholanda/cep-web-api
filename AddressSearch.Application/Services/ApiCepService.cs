using AddressSearch.Domain.Entities;
using AddressSearch.Domain.Interfaces.Repositories;
using AddressSearch.Domain.Interfaces.Services;

namespace AddressSearch.Application.Services;

public class ApiCepService : IApiCepService
{
    private readonly IApiCepRepository _apiCepRepository;

    public ApiCepService(IApiCepRepository apiCepRepository)
    {
        _apiCepRepository = apiCepRepository;
    }

    public async Task<Address> GetAddressByCep(string cep)
    {
        Address address = await _apiCepRepository.GetAddressByCep(cep);
        return address;
    }
}