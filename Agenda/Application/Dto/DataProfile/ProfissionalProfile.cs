using Agenda.Domain.Models;
using AutoMapper;

namespace Agenda.Application.Dto.DataProfile
{
    public class ProfissionalProfile : Profile
    {
        public ProfissionalProfile()
        {
            CreateMap<ProfissionalDto, Profissional>();
            CreateMap<ProfissionalUpdate, Profissional>();
        }

    }
}