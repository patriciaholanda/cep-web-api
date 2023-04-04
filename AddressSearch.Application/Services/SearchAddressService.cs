using AddressSearch.Domain.Entities;
using AddressSearch.Domain.Interfaces.Services;

namespace AddressSearch.Application.Services
{
    public class SearchAddressService : ISearchAddressService
    {
        private readonly IViaCepService _viaCepService;
        private readonly IApiCepService _apiCepService;
        private readonly IAwesomeApiCepService _awesomeApiCepService;

        public SearchAddressService(
            IViaCepService viaCepService,
            IApiCepService apiCepService,
            IAwesomeApiCepService awesomeApiCepService)
        {
            _viaCepService = viaCepService;
            _apiCepService = apiCepService;
            _awesomeApiCepService = awesomeApiCepService;
        }

        public async Task<Address> GetAddressByCep(string cep)
        {
            Address address = await _viaCepService.GetAddressByCep(cep);
            return address;
        }

        public async Task<List<Address>> GetAddressByStreet(string state, string city, string street)
        {
            List<Address> addresses = await _viaCepService.GetAddressByStreet(state, city, street);
            return addresses;
        }
    }
}