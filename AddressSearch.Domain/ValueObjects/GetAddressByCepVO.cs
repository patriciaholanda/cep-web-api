namespace AddressSearch.Domain.ValueObjects;

public class GetAddressByCepVO
{
    public string Cep { get; set; }

    public GetAddressByCepVO(string cep)
    {
        Cep = cep ?? throw new ArgumentNullException(nameof(cep));
    }

    //public void Validate
}
