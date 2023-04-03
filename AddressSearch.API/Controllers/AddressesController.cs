using AddressSearch.Application;
using AddressSearch.Application.Models;
using AddressSearch.Application.UseCases.AddressUseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AddressSearch.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressesController : ControllerBase
{
    private readonly IGetAddressByCepUseCase _getAddressByCepUseCase;
    private readonly IGetAddressByStreetUseCase _getAddressByStreetUseCase;

    public AddressesController(IGetAddressByCepUseCase getAddressByCepUseCase, IGetAddressByStreetUseCase getAddressByStreetUseCase)
    {
        _getAddressByCepUseCase = getAddressByCepUseCase;
        _getAddressByStreetUseCase = getAddressByStreetUseCase;
    }

    [HttpGet("{cep}")]
    public async Task<ActionResult<AddressModel>> GetAddressByCepUseCase(string cep)
    {
        try
        {
            Response response = await _getAddressByCepUseCase.ExecuteAsync(cep);
            return StatusCode((int)response.StatusCode, response);
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
    public async Task<ActionResult<AddressModel>> GetAddressByStreetUseCase(string state, string city, string street)
    {
        try
        {
            Response response = await _getAddressByStreetUseCase.ExecuteAsync(state, city, street);
            return StatusCode((int)response.StatusCode, response);
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