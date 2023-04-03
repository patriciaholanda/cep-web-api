using AutoMapper;
using AddressSearch.Application.Models;
using AddressSearch.Domain.Entities;

namespace AddressSearch.Application.Mappers
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressModel>().ReverseMap();
        }
    }
}