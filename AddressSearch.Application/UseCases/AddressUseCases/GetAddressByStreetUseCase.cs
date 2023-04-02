using AutoMapper;
using AddressSearch.Application.Models;
using AddressSearch.Application.UseCases.AddressUseCases.Interfaces;
using AddressSearch.Domain.Entities;
using AddressSearch.Domain.Interfaces;
using System.Net;
using System.Runtime.ConstrainedExecution;

namespace AddressSearch.Application.UseCases.AddressUseCases
{
    public class GetAddressByStreetUseCase : IGetAddressByStreetUseCase
    {
        private readonly IExternalApiRepository _externalAPIRepository;
        private readonly IMapper _mapper;

        public GetAddressByStreetUseCase(IExternalApiRepository externalAPIRepository, IMapper mapper)
        {
            _externalAPIRepository = externalAPIRepository;
            _mapper = mapper;
        }

        public async Task<Response> ExecuteAsync(string state, string city, string street)
        {
            List<Address> addresses = await _externalAPIRepository.GetAddressByStreet(state, city, street);
            List<AddressModel> addressModels = _mapper.Map<List<AddressModel>>(addresses);
            Response response = new(HttpStatusCode.OK, true, addressModels);

            return response;
        }
    }
}