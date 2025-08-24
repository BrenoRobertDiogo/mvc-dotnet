using Microsoft.EntityFrameworkCore;
using Models.Clientes;
using Models.Pedidos;
using Models.Produtos;

namespace mvc_dotnet.Contexts
{
    public class LojaContext : DbContext
    {
        public LojaContext(DbContextOptions<LojaContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoProduto> ItensPedido { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Produto
            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("Produtos");
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Nome)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(p => p.Descricao)
                      .HasMaxLength(500);

                entity.Property(p => p.Preco)
                      .HasColumnType("decimal(18,2)");

                entity.Property(p => p.Categoria)
                      .HasMaxLength(50);

                entity.HasMany(p => p.PedidoProduto)
                      .WithOne(i => i.Produto)
                      .HasForeignKey(i => i.ProdutoId);
            });

            // Cliente
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Clientes");
                entity.HasKey(c => c.Id);

                entity.Property(c => c.Nome)
                      .IsRequired()
                      .HasMaxLength(150);

                entity.Property(c => c.Email)
                      .HasMaxLength(100);

                entity.Property(c => c.CpfCnpj)
                      .HasMaxLength(20);

                entity.Property(c => c.Telefone)
                      .HasMaxLength(20);

                entity.Property(c => c.Endereco)
                      .HasMaxLength(250);

                entity.HasMany(c => c.Pedidos)
                      .WithOne(p => p.Cliente)
                      .HasForeignKey(p => p.ClienteId);
            });

            // Pedido
            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.ToTable("Pedidos");
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Status)
                      .HasMaxLength(50);

                entity.Property(p => p.ValorTotal)
                      .HasColumnType("decimal(18,2)");

                entity.HasMany(p => p.Itens)
                      .WithOne(i => i.Pedido)
                      .HasForeignKey(i => i.PedidoId);
            });

            // ItemPedido
            modelBuilder.Entity<PedidoProduto>(entity =>
            {
                entity.ToTable("PedidoProduto");
                entity.HasKey(i => i.Id);

                entity.Property(i => i.PrecoUnitario)
                      .HasColumnType("decimal(18,2)");

                entity.Ignore(i => i.Subtotal);
            });
        }
    }
}
