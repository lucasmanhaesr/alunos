using Alunos.Data.Contexts;
using Alunos.Data.Interface;
using Alunos.Models;
using Microsoft.EntityFrameworkCore;

namespace Alunos.Data.Repository
{
    public class ClienteRepository(DatabaseContext context) : IClienteRepository //Construtor simplificado e implementação da interface
    {
        private readonly DatabaseContext _context = context;

        public void Add(ClienteModel cliente)
        {
            _context.Cliente.Add(cliente);
            _context.SaveChanges();
        }

        public void Update(ClienteModel cliente)
        {
            _context.Cliente.Update(cliente);
            _context.SaveChanges();
        }

        public void Delete(ClienteModel cliente)
        {
            _context.Cliente.Remove(cliente);
            _context.SaveChanges();
        }

        public ClienteModel getById(int id)
        {
            var cliente = _context.Cliente.Find(id);
            if (cliente == null)
                throw new KeyNotFoundException($"Cliente com id {id} não encontrado.");
            return cliente;
        }

        public IEnumerable<ClienteModel> GetAll()
        {
            return _context.Cliente.Include(c => c.Representante).ToList();
        }
    }
}
