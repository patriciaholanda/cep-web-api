using AddressSearch.Application.Dtos;
using AddressSearch.Domain.Entities;
using AddressSearch.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace AddressSearch.Infrastructure.Repositories;

public class ViaCepRepository : IExternalApiRepository
{
    private readonly string _baseURL;

    public ViaCepRepository(IConfiguration configuration)
    {
        _baseURL = configuration.GetSection("BaseUrl:MainApi").Value
                   ?? throw new ArgumentNullException("BaseUrl setting is missing");
    }

    public async Task<Address> GetAddressByCep(string cep)
    {
        using HttpClient client = new ();
        var response = await client.GetAsync($"{ _baseURL}/{cep}/json/");
        
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error: {response.ReasonPhrase} \n" +
                                           $"Request: {response.RequestMessage.Method} \n" +
                                           $"Uri: {response.RequestMessage.RequestUri}");
        }

        string? content = await response.Content.ReadAsStringAsync();
        AddressViaCepDto? addressDto = JsonConvert.DeserializeObject<AddressViaCepDto>(content);
        Address address = new(addressDto.Logradouro, addressDto.Bairro, addressDto.Localidade, addressDto.Uf, addressDto.Cep);
        
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
        List<AddressViaCepDto>? addressDtos = new();
        addressDtos = JsonConvert.DeserializeObject<List<AddressViaCepDto>>(content);
        List<Address> addresses = new();

        if (!addressDtos.Any())
            return addresses;

        foreach (var addressDto in addressDtos)
        {
            addresses.Add(new(addressDto.Logradouro, addressDto.Bairro, addressDto.Localidade, addressDto.Uf, addressDto.Cep));
        }

        return addresses;
    }
}