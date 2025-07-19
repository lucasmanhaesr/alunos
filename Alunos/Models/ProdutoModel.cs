namespace Alunos.Models
{
    public class ProdutoModel
    {
        public int ProdutoId { get; set; }
        public string? Nome { get; set; }
        public decimal? Preco { get; set; }
        public string? Descricao { get; set; }
        public int FornecedorId { get; set; }
        public FornecedorModel? Fornecedor { get; set; }
        public List<PedidoProdutoModel>? PedidoProdutos { get; set; }
    }
}
