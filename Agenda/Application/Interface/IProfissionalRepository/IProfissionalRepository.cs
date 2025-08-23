using Agenda.Application.Dto.Request.ProfissionalRequest;
using Agenda.Application.Dto.Response.ProfissionalResponse;

namespace Agenda.Application.Interface.IProfissionalRepository
{
    public interface IProfissionalRepository
    {
        Task<ListProfissionalResponse> ListProfissional(ListProfissionalRequest request); 

        //Task<> List
    }
}
