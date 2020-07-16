namespace Sistema.Datos
{
    using Microsoft.EntityFrameworkCore;
    using Sistema.Entidades.Almacen;
    using Sistema.Entidades.Ordenes;

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

        // public DbContextSistema(DbContextOptions<DbContextSistema> options) : base(options)
        // {

        // }

    }

}
