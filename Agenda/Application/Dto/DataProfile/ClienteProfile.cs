using Agenda.Application.Dto;
using Agenda.Domain.Models;
using Agenda.Application.Dto.Request.ClienteRequest;
using AutoMapper;

namespace Agenda.Application.Dto.DataProfile
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
