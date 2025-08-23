using Agenda.Domain.Models;
using Agenda.Infrastructure.Repository;

namespace Agenda.Application.Services
{
    public class ClienteService : GenericService<Cliente>
    {
        public ClienteService(GenericRepository<Cliente> repository) : base(repository)
        {
        }
    }
}