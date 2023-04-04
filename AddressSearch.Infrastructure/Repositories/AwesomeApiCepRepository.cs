using AddressSearch.Application.DTOs;
using AddressSearch.Domain.Entities;
using AddressSearch.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace AddressSearch.Infrastructure.Repositories
{
    public class AwesomeApiCepRepository : IAwesomeApiCepRepository
    {
        private readonly string _baseURL;

        public AwesomeApiCepRepository(IConfiguration configuration)
        {
            _baseURL = configuration.GetSection("BaseUrl:SecondBackupApi").Value
                       ?? throw new ArgumentNullException("BaseUrl setting is missing");
        }

        public async Task<Address> GetAddressByCep(string cep)
        {
            using HttpClient client = new();
            var response = await client.GetAsync($"{_baseURL}/{cep}");

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error: {response.ReasonPhrase} \n" +
                                               $"Request: {response?.RequestMessage?.Method} \n" +
                                               $"Uri: {response?.RequestMessage?.RequestUri}");
            }

            string? content = await response.Content.ReadAsStringAsync();
            var addressDto = JsonConvert.DeserializeObject<AddressAwesomeApiCepDto>(content) ?? 
                throw new Exception($"Error: Not Found");

            Address address = new(addressDto.Cep, addressDto.State, addressDto.City, addressDto.District, addressDto.Address);
            return address;
        }
    }
}
