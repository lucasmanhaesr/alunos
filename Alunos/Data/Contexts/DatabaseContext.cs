using Alunos.Models;
using Microsoft.EntityFrameworkCore;

namespace Alunos.Data.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        { }

        protected DatabaseContext() 
        { }

        public virtual DbSet<ClienteModel> Cliente { get; set; }
        public virtual DbSet<RepresentanteModel> Representantes { get; set; }
        public virtual DbSet<FornecedorModel> Fornecedores {get; set;}
        public virtual DbSet<LojaModel> Lojas {get; set;}
        public virtual DbSet<PedidoModel> Pedidos {get; set;}
        public virtual DbSet<PedidoProdutoModel> PedidoProdutos {get; set;}
        public virtual DbSet<ProdutoModel> Produtos {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração para RepresentanteModel
            modelBuilder.Entity<RepresentanteModel>(entity => 
            {
                entity.ToTable("Representantes");
                entity.HasKey(e => e.RepresentanteId);
                entity.Property(e => e.NomeRepresentante).IsRequired();
                entity.HasIndex(e => e.Cpf).IsUnique();
            });

            // Configuração para ClienteModel
            modelBuilder.Entity<ClienteModel>(entity => 
            {
                entity.ToTable("Clientes");
                entity.HasKey(e => e.ClienteId);
                entity.Property(e => e.NomeCliente).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.DataNascimento).HasColumnType("date");
                entity.Property(e => e.Observacao).HasMaxLength(500);
                //Relacionamento com Representantes - 1 Cliente pode ter 1 Representante e Representante pode ter muitos Clientes
                entity
                    .HasOne(e => e.Representante)
                        .WithMany()
                            .HasForeignKey(e => e.RepresentanteId)
                                .IsRequired();
            });

            // Configuração para LojaModel
            modelBuilder.Entity<LojaModel>(entity =>
            {
                entity.ToTable("Lojas");
                entity.HasKey(l => l.LojaId);
                entity.Property(l => l.Nome).IsRequired();
                entity.Property(l => l.Endereco);
                // Relacionamento com Pedidos - 1 Loja pode ter varios Pedidos e Pedidos pode ter 1 Loja
                entity.HasMany(l => l.Pedidos)
                        .WithOne(p => p.Loja)
                            .HasForeignKey(p => p.LojaId);
            });

            // Configuração para PedidoModel
            modelBuilder.Entity<PedidoModel>(entity =>
            {
                entity.ToTable("Pedidos");
                entity.HasKey(p => p.PedidoId);
                entity.Property(p => p.DataPedido).HasColumnType("DATE");
                // Relacionamento com ClienteModel - Pedido podem ter 1 Cliente e 1 Cliente pode ter varios pedidos 
                entity.HasOne(p => p.Cliente)
                        .WithMany()
                            .HasForeignKey(p => p.ClienteId);
                // Configuração de muitos para muitos: PedidoModel e ProdutoModel
                entity.HasMany(p => p.PedidoProdutos)
                        .WithOne(pp => pp.Pedido)
                            .HasForeignKey(pp => pp.PedidoId);
            });

            // Configuração para PedidoProdutoModel (relacionamento muitos-para-muitos)
            modelBuilder.Entity<PedidoProdutoModel>(entity =>
            {
                entity.ToTable("PedidoProduto");
                entity.HasKey(pp => new { pp.PedidoId, pp.ProdutoId });
                entity.HasOne(pp => pp.Pedido)
                        .WithMany(p => p.PedidoProdutos)
                            .HasForeignKey(pp => pp.PedidoId);
                entity.HasOne(pp => pp.Produto)
                        .WithMany(p => p.PedidoProdutos)
                            .HasForeignKey(pp => pp.ProdutoId);
            });

            // Configuração para ProdutoModel
            modelBuilder.Entity<ProdutoModel>(entity =>
            {
                entity.ToTable("Produtos");
                entity.HasKey(p => p.ProdutoId);
                entity.Property(p => p.Nome).IsRequired();
                entity.Property(p => p.Descricao);
                entity.Property(p => p.Preco).HasColumnType("NUMBER(18,2)");
                // Relacionamento com FornecedorModel
                entity.HasOne(p => p.Fornecedor)
                        .WithMany(f => f.Produtos)
                            .HasForeignKey(p => p.FornecedorId);
            });

            // Configuração para FornecedorModel
            modelBuilder.Entity<FornecedorModel>(entity =>
            {
                entity.ToTable("Fornecedores");
                entity.HasKey(f => f.FornecedorId);
                entity.Property(f => f.Nome).IsRequired();
            });
        }
    }
}