namespace Sistema.Web.Datos
{
    using Microsoft.EntityFrameworkCore;
    using Sistema.Web.Datos.Mapping.Almacen;
    using Sistema.Web.Datos.Mapping.Usuario;
    using Sistema.Web.Entidades.Almacen;
    using Sistema.Web.Entidades.Ordenes;
    using Sistema.Web.Entidades.Usuario;

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
