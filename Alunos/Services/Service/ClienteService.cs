using Alunos.Data.Interface;
using Alunos.Models;
using Alunos.Services.Interface;

namespace Alunos.Services.Service
{
    public class ClienteService(IClienteRepository clienteRepository) : IClienteService
    {
        private readonly IClienteRepository _clienteRepository = clienteRepository;

        public void Add(ClienteModel cliente) => _clienteRepository.Add(cliente);

        public void Update(ClienteModel cliente) => _clienteRepository.Update(cliente);

        public void Delete(ClienteModel cliente) => _clienteRepository.Delete(cliente);

        public ClienteModel GetById(int id) => _clienteRepository.getById(id);

        public IEnumerable<ClienteModel> GetAll() => _clienteRepository.GetAll();
    }
}
