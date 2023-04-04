using AddressSearch.Domain.Entities;
using AddressSearch.Domain.Interfaces.Repositories;
using AddressSearch.Domain.Interfaces.Services;

namespace AddressSearch.Application.Services;

public class ViaCepService : IViaCepService
{
    private readonly IViaCepRepository _viaCepRepository;

    public ViaCepService(IViaCepRepository viaCepRepository, IApiCepService apiCepService)
    {
        _viaCepRepository = viaCepRepository;
    }

    public async Task<Address> GetAddressByCep(string cep)
    {
        Address address = await _viaCepRepository.GetAddressByCep(cep);
        return address;
    }

    public async Task<List<Address>> GetAddressByStreet(string state, string city, string street)
    {
        List<Address> addresses = await _viaCepRepository.GetAddressByStreet(state, city, street);
        return addresses;
    }
}