using Microsoft.EntityFrameworkCore;

namespace Alunos.Data.Contexts
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions options) : base(options)
        { }

        protected DatabaseContext() 
        { }
    }
}
