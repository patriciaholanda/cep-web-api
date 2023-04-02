using AutoMapper;
using AddressSearch.Application.Models;
using AddressSearch.Application.UseCases.AddressUseCases.Interfaces;
using AddressSearch.Domain.Entities;
using AddressSearch.Domain.Interfaces;
using System.Net;

namespace AddressSearch.Application.UseCases.AddressUseCases;

public class GetAddressByCepUseCase : IGetAddressByCepUseCase
{
    private readonly IExternalApiRepository _externalAPIRepository;
    private readonly IMapper _mapper;

    public GetAddressByCepUseCase(IExternalApiRepository externalAPIRepository, IMapper mapper)
    {
        _externalAPIRepository = externalAPIRepository;
        _mapper = mapper;
    }

    public async Task<Response> ExecuteAsync(string cep)
    {
        Address address = await _externalAPIRepository.GetAddressByCep(cep);
        AddressModel addressModel = _mapper.Map<AddressModel>(address);
        Response response = new(HttpStatusCode.OK, true, addressModel);
        return response; 
    }
}