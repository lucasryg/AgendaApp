

using Agenda.Dto.Request.ClienteRequest;
using Agenda.Models;
using AutoMapper;

namespace Agenda.Dto.DataProfile
{ 
    public class ClienteProfile : Profile
    {

        public ClienteProfile()
        {
            CreateMap<Cliente, ClienteDto>();
            CreateMap<ClienteDto, Cliente>();

            CreateMap<ClienteCreateDto, Cliente>();
            CreateMap<ClienteUpdateDto, Cliente>();
        }
    }
}
