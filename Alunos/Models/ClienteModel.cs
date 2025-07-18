namespace Alunos.Models
{
    public class ClienteModel
    {
        public int ClienteId { get; set; }
        public string? NomeCliente { get; set; }
        public string? SobrenomeCliente { get; set; }
        public string? Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Observacao { get; set; }
        public int RepresentanteId { get; set; }
        public RepresentanteModel? Representante { get; set; }
    }
}
