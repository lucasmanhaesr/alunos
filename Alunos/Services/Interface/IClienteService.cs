using Alunos.Models;

namespace Alunos.Services.Interface
{
    public interface IClienteService
    {
        void Add(ClienteModel cliente);
        void Update(ClienteModel cliente);
        void Delete(ClienteModel cliente);
        ClienteModel GetById(int id);
        IEnumerable<ClienteModel> GetAll();
    }
}
