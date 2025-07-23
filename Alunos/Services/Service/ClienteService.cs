using Alunos.Data.Repository;
using Alunos.Models;
using Alunos.Services.Interface;

namespace Alunos.Services.Service
{
    public class ClienteService(ClienteRepository clienteRepository) : IClienteService
    {
        private readonly ClienteRepository _clienteRepository = clienteRepository;

        public void Add(ClienteModel cliente)
        {
            _clienteRepository.Add(cliente);
        }

        public void Update(ClienteModel cliente)
        {
            _clienteRepository.Update(cliente);
        }

        public void Delete(ClienteModel cliente)
        {
            _clienteRepository.Delete(cliente);
        }

        public ClienteModel GetById(int id)
        {
            return _clienteRepository.getById(id);
        }

        public IEnumerable<ClienteModel> GetAll()
        {
            return _clienteRepository.GetAll();
        }
    }
}
