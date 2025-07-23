using Alunos.Models;

namespace Alunos.Data.Interface
{
    public interface IClienteRepository
    {
        void Add(ClienteModel cliente);
        void Update(ClienteModel cliente);
        void Delete(ClienteModel cliente);
        IEnumerable<ClienteModel> GetAll();
        ClienteModel getById(int id);
    }
}
