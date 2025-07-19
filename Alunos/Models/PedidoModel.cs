namespace Alunos.Models
{
    public class PedidoModel
    {
        public int PedidoId { get; set; }
        public DateTime DataPedido { get; set; }
        public int ClienteId { get; set; }
        public ClienteModel? Cliente { get; set; }
        public int LojaId { get; set; }
        public LojaModel? Loja { get; set; }
        public List<PedidoProdutoModel>? PedidoProdutos { get; set; }
    }
}
