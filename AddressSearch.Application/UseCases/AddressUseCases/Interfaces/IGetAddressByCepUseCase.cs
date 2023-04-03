namespace AddressSearch.Application.UseCases.AddressUseCases.Interfaces;

public interface IGetAddressByCepUseCase
{
    public Task<Response> ExecuteAsync(string cep);
}