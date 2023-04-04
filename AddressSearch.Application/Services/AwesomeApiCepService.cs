using AddressSearch.Domain.Entities;
using AddressSearch.Domain.Interfaces.Repositories;
using AddressSearch.Domain.Interfaces.Services;

namespace AddressSearch.Application.Services;

public class AwesomeApiCepService : IAwesomeApiCepService
{
    private readonly IAwesomeApiCepRepository _awesomeApiCepRepository;
    
    public AwesomeApiCepService(IAwesomeApiCepRepository awesomeApiCepRepository)
    {
        _awesomeApiCepRepository = awesomeApiCepRepository;
    }
    public async Task<Address> GetAddressByCep(string cep)
    {
        Address address = await _awesomeApiCepRepository.GetAddressByCep(cep);
        return address;
    }
}