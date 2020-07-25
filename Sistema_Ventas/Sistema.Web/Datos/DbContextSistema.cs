namespace Api.Datos
{
    using Api.Datos.Mapping.Almacen;
    using Api.Datos.Mapping.Usuario;
    using Api.Entidades.Almacen;
    using Api.Entidades.Ordenes;
    using Api.Entidades.Usuario;
    using Microsoft.EntityFrameworkCore;

    public class DbContextSistema : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<ProductoFoto> ProductoFotos { get; set; }

        public DbSet<DetalleCarrito> DetalleCarritos { get; set; }

        public DbSet<Carrito> Carritos { get; set; }

        public DbSet<Orden> Ordenes { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<Pago> Pagos { get; set; }

        public DbSet<Administrador> Administradores { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Rol> Roles { get; set; }

        public Dbset<Slider> Sliders { get; set; }

        public DbContextSistema(DbContextOptions<DbContextSistema> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ProductoMap());
            modelBuilder.ApplyConfiguration(new AdministradorMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new RolMap());
        }
    }
}
