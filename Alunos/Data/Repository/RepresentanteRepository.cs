using Alunos.Data.Contexts;
using Alunos.Data.Interface;
using Alunos.Models;

namespace Alunos.Data.Repository
{
    public class RepresentanteRepository(DatabaseContext context) : IRepresentanteRepository
    {
        private readonly DatabaseContext _context = context;

        public void Add(RepresentanteModel representante)
        {
            _context.Representantes.Add(representante);
            _context.SaveChanges();
        }

        public void Update(RepresentanteModel representante)
        {
            _context.Representantes.Update(representante);
            _context.SaveChanges();
        }

        public void Delete(RepresentanteModel representante)
        {
            _context.Representantes.Remove(representante);
            _context.SaveChanges();
        }

        public RepresentanteModel getById(int id)
        {
            var representante = _context.Representantes.Find(id);
            return representante;
        }

        public IEnumerable<RepresentanteModel> GetAll()
        {
            return _context.Representantes.ToList();
        }
    }
}
