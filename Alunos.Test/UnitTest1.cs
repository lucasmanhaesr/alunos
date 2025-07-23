namespace Alunos.Test
{
    public class UnitTest1
    {
        [Fact] //Anotação que informa que é um método de teste
        public void VerificaMaioriadade_DeveRetornarTrueSeMaior() 
        {
            //Arrange (Preparação)
            var dataNascimento = new DateTime(1998, 8, 27);
            var hoje = DateTime.Now;
            var maioridade = hoje.Year - dataNascimento.Year;

            if (dataNascimento > hoje.AddYears(-maioridade)) maioridade--;

            //Act (Ação)
            var ehMaiorDeIdade = maioridade >= 18;

            //Assert (Validação)
            Assert.True(ehMaiorDeIdade); //Se for maior de idade retorna true
        }

        [Fact] //Anotação que informa que é um método de teste
        public void VerificaMaioriadade_DeveRetornarTrueSeMenor()
        {
            //Arrange (Preparação)
            var dataNascimento = new DateTime(2020, 4, 15);
            var hoje = DateTime.Now;
            var maioridade = hoje.Year - dataNascimento.Year;

            if (dataNascimento > hoje.AddYears(-maioridade)) maioridade--;

            //Act (Ação)
            var ehMaiorDeIdade = maioridade < 18;

            //Assert (Validação)
            Assert.True(ehMaiorDeIdade); //Se for maior de idade retorna true
        }
    }
}
