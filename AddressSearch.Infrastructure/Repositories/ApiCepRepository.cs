using AddressSearch.Application.DTOs;
using AddressSearch.Domain.Entities;
using AddressSearch.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace AddressSearch.Infrastructure.Repositories;

public class ApiCepRepository : IExternalApiRepository
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

    public async Task<List<Address>> GetAddressByStreet(string state, string city, string street)
    {
        using HttpClient client = new();

        var response = await client.GetAsync($"{_baseURL}/{state}/{city}/{street}/json/");

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error: {response.ReasonPhrase} \n" +
                                           $"Request: {response.RequestMessage.Method} \n" +
                                           $"Uri: {response.RequestMessage.RequestUri}");
        }

        string? content = await response.Content.ReadAsStringAsync();
        List<AddressApiCepDto>? addressDtos = new();
        addressDtos = JsonConvert.DeserializeObject<List<AddressApiCepDto>>(content);
        List<Address> addresses = new();

        if (!addressDtos.Any())
            return addresses;

        foreach (var addressDto in addressDtos)
        {
            addresses.Add(new(addressDto.Address, addressDto.District, addressDto.City, addressDto.State, addressDto.Code));
        }

        return addresses;
    }
}