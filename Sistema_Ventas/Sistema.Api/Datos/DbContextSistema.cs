namespace Sistema.Api.Datos
{
    using Microsoft.EntityFrameworkCore;
    using Sistema.Api.Datos.Mapping.Almacen;
    using Sistema.Api.Datos.Mapping.Usuario;
    using Sistema.Api.Entidades.Almacen;
    using Sistema.Api.Entidades.Ordenes;
    using Sistema.Api.Entidades.Usuario;

    public class DbContextSistema : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Marca> Marcas { get; set; }

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

        //public DbSet<Slider> Sliders { get; set; }

        public DbContextSistema(DbContextOptions<DbContextSistema> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new MarcaMap());
            modelBuilder.ApplyConfiguration(new ProductoMap());
            modelBuilder.ApplyConfiguration(new AdministradorMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new RolMap());
            modelBuilder.ApplyConfiguration(new ProductoFotoMap());
        }
    }
}
