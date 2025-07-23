using Alunos.Models;

namespace Alunos.Data.Interface
{
    public interface IRepresentanteRepository
    {
        void Add(RepresentanteModel representante);
        void Update(RepresentanteModel representante);
        void Delete(RepresentanteModel representante);
        IEnumerable<RepresentanteModel> GetAll();
        RepresentanteModel getById(int id);
    }
}
