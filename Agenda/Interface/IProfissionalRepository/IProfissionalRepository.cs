using Agenda.Dto.Request.ProfissionalRequest;
using Agenda.Dto.Response.ProfissionalResponse;

namespace Agenda.Interface.IProfissionalRepository
{
    public interface IProfissionalRepository
    {
        Task<ListProfissionalResponse> ListProfissional(ListProfissionalRequest request); 

        //Task<> List
    }
}
