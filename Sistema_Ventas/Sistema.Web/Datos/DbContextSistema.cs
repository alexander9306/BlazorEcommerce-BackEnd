namespace Sistema.Web.Datos
{
    using Microsoft.EntityFrameworkCore;
    using Sistema.Web.Entidades.Almacen;
    using Sistema.Web.Entidades.Ordenes;
    using Sistema.Web.Entidades.Usuario;

    public class DbContextSistema : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<DetalleCarrito> DetalleCarritos { get; set; }

        public DbSet<Carrito> Carritos { get; set; }

        public DbSet<Orden> Ordenes { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<Pago> Pagos { get; set; }

        public DbSet<Administrador> Administradores { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Rol> Roles { get; set; }

        public DbContextSistema(DbContextOptions<DbContextSistema> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>()
                .HasIndex(p => p.Nombre)
                .IsUnique();
            modelBuilder.Entity<Categoria>()
                .HasIndex(p => p.Nombre)
                .IsUnique();
            modelBuilder.Entity<Administrador>()
                .HasIndex(p => p.Email)
                .IsUnique();
            modelBuilder.Entity<Administrador>()
                .HasIndex(p => p.Username)
                .IsUnique();
            modelBuilder.Entity<Cliente>()
                .HasIndex(p => p.Email)
                .IsUnique();
        }
    }
}
