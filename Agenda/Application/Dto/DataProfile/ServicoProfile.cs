using Agenda.Domain.Models;
using AutoMapper;

namespace Agenda.Application.Dto.DataProfile
{
    public class ServicoProfile : Profile
    {
        public ServicoProfile()
        {
            CreateMap<ServicoDto, Servico>();
            CreateMap<ServicoCreate, Servico>();
            CreateMap<ServicoUpdate, Servico>();
        }
    }
}
