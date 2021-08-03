using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DtoModels;

namespace Library.Interfaces
{
    public interface IClientLogic
    {
        Task<List<ClientDTO>> GetClients();
        Task<ClientDTO> GetClient(Guid id);
        Task CreateClient(ClientDTO client);
        Task EditClient(ClientDTO editedClient);
        Task DeleteClient(Guid id);
    }
}
