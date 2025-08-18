using Agenda.Models;
using Agenda.Repository;

namespace Agenda.Services
{
    public class ClienteService : GenericService<Cliente>
    {
        public ClienteService(GenericRepository<Cliente> repository) : base(repository)
        {
        }
    }
}