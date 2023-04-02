namespace AddressSearch.Application.UseCases.AddressUseCases.Interfaces;

public interface IGetAddressByStreetUseCase
{
    public Task<Response> ExecuteAsync(string state, string city, string street);
}