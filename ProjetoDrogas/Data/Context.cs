using Microsoft.EntityFrameworkCore;
using ProjetoDrogas.Models;

namespace ProjetoDrogas.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Categoria> CategoriaDeProdutos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<ItemVenda> ItemVendas { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<ItemCompra> ItemCompras { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("tbCliente");
            modelBuilder.Entity<Fornecedor>().ToTable("tbFornecedor");
            modelBuilder.Entity<Categoria>().ToTable("tbCategoria");
            modelBuilder.Entity<Produto>().ToTable("tbProduto");
            modelBuilder.Entity<Venda>().ToTable("tbVenda");
            modelBuilder.Entity<ItemVenda>().ToTable("tbItemVenda");
            modelBuilder.Entity<Compra>().ToTable("tbCompra");
            modelBuilder.Entity<ItemCompra>().ToTable("tbItemCompra");

        }
    
    }
}
