using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.DtoModels;
using Library.Interfaces;
using AutoMapper;
using Library.Models;
using System.Data.Entity;

namespace Library.Logic
{
    public class ClientLogic : IClientLogic
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public ClientLogic(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task CreateClient(ClientDTO client)
        {
            var mappedClient = _mapper.Map<ClientDTO, Client>(client);

            _context.Clients.Add(mappedClient);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClient(Guid id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.ID == id);

            if (id != client.ID)
                throw new Exception("Client cannot be find");

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }

        public async Task EditClient(ClientDTO editedClient)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.ID == editedClient.ID);

            if (editedClient.ID != client.ID)
                throw new Exception("Client cannot be find");

            client.Name = editedClient.Name ?? client.Name;

            await _context.SaveChangesAsync();
        }

        public async Task<ClientDTO> GetClient(Guid id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.ID == id);

            if (id != client.ID)
                throw new Exception("Client cannot be find");

            var mappedClient = _mapper.Map<Client, ClientDTO>(client);
            return mappedClient;
        }

        public async Task<List<ClientDTO>> GetClients()
        {
            var clients = await _context.Clients.ToListAsync();
            var mappedClients = _mapper.Map<List<Client>, List<ClientDTO>>(clients);

            return mappedClients;
        }
    }
}
