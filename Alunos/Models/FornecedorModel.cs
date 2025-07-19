namespace Alunos.Models
{
    public class FornecedorModel
    {
        public int FornecedorId { get; set; }
        public string? Nome { get; set; }
        public List<ProdutoModel>? Produtos { get; set; }
    }
}
