using AddressSearch.Application.DTOs;
using AddressSearch.Domain.Entities;
using AddressSearch.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace AddressSearch.Infrastructure.Repositories;

public class ApiCepRepository : IApiCepRepository
{
    private readonly string _baseURL;

    public ApiCepRepository(IConfiguration configuration)
    {
        _baseURL = configuration.GetSection("BaseUrl:FirstBackupApi").Value
                   ?? throw new ArgumentNullException("BaseUrl setting is missing");
    }

    public async Task<Address> GetAddressByCep(string cep)
    {
        using HttpClient client = new();
        var response = await client.GetAsync($"{_baseURL}/{cep}.json");

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error: {response.ReasonPhrase} \n" +
                                           $"Request: {response.RequestMessage.Method} \n" +
                                           $"Uri: {response.RequestMessage.RequestUri}");
        }

        string? content = await response.Content.ReadAsStringAsync();
        AddressApiCepDto? addressDTO = JsonConvert.DeserializeObject<AddressApiCepDto>(content);
        Address address = new(addressDTO.Address, addressDTO.District, addressDTO.City, addressDTO.State, addressDTO.Code);

        return address;
    }
}