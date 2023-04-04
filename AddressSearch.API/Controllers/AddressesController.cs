using AddressSearch.Application.Models;
using AddressSearch.Domain.Entities;
using AddressSearch.Domain.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AddressSearch.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressesController : ControllerBase
{
    private readonly ISearchAddressService _searchAddressService;
    private readonly IMapper _mapper;

    public AddressesController(ISearchAddressService searchAddressService, IMapper mapper)
    {
        _searchAddressService = searchAddressService;
        _mapper = mapper;
    }

    [HttpGet("{cep}")]
    public async Task<ActionResult<AddressModel>> GetAddressByCep(string cep)
    {
        try
        {
            Address address = await _searchAddressService.GetAddressByCep(cep);
            AddressModel addressModel = _mapper.Map<AddressModel>(address);
            return Ok(addressModel);
        }
        catch (HttpRequestException ex)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{state}/{city}/{street}")]
    public async Task<ActionResult<List<AddressModel>>> GetAddressByStreet(string state, string city, string street)
    {
        try
        {
            List<Address> addresses = await _searchAddressService.GetAddressByStreet(state, city, street);
            List<AddressModel> addressModel = _mapper.Map<List<AddressModel>>(addresses);
            return Ok(addressModel);
        }
        catch (HttpRequestException ex)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}