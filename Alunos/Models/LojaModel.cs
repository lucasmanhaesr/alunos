﻿namespace Alunos.Models
{
    public class LojaModel
    {
        public int LojaId { get; set; }
        public string? Nome { get; set; }
        public string? Endereco { get; set; }
        public List<PedidoModel>? Pedidos { get; set; }
    }
}