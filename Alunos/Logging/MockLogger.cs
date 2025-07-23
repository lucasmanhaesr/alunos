namespace Alunos.Logging
{
    public class MockLogger : ICustomLogger
    {
        public void log(string mensagem)
        {
            Console.WriteLine(mensagem);
        }
    }
}
