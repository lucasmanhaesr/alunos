namespace Alunos.Logging
{
    public class FileLogger : ICustomLogger
    {
        public void log(string mensagem)
        {
            Console.WriteLine("File: " + mensagem);
        }
    }
}
