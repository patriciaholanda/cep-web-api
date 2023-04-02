namespace AddressSearch.Application.Dtos;

public class AddressViaCepDto
{
    public string Cep { get; set; }
    public string Uf { get; set; }
    public string Localidade { get; set; }
    public string Bairro { get; set; }
    public string Logradouro { get; set; }
}