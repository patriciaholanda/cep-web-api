namespace AddressSearch.Domain.Entities;
public class Address
{
    public string Zipcode { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public string Street { get; set; }
    
    public Address(string zipcode, string state, string city, string district, string street)
    {
        Zipcode = zipcode ?? throw new ArgumentNullException(nameof(zipcode));
        State = state ?? throw new ArgumentNullException(nameof(state));
        City = city ?? throw new ArgumentNullException(nameof(city));
        District = district ?? throw new ArgumentNullException(nameof(district));
        Street = street ?? throw new ArgumentNullException(nameof(street));
    }
    public Address() { }
}