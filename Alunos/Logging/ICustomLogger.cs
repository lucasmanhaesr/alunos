using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Alunos.Logging
{
    public interface ICustomLogger
    {
        void log(string mensagem);
    }
}
