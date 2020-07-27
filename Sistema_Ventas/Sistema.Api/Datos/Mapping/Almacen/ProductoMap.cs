namespace Sistema.Api.Datos.Mapping.Almacen
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Sistema.Api.Entidades.Almacen;

    public class ProductoMap : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.HasIndex(p => p.Nombre)
                .IsUnique();
            builder.HasData(
                new Producto
                {
                    Id = 1,
                    CategoriaId = 1,
                    Nombre = "Thinkpad T440 - Nuevo",
                    Precio = 55000.00M,
                    Estado = true,
                    Marca = "Lenovo",
                    Descripcion = "Los clientes empresariales han utilizado durante mucho tiempo la familia de portátiles empresariales de gama alta Lenovo, anteriormente IBM, ThinkPad",
                    Stock = 15, 
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                },
                new Producto
                {
                    Id = 2,
                    CategoriaId = 1,
                    Nombre = "Latitude E6540 - Nuevo",
                    Precio = 44000.00M,
                    Estado = true,
                    Marca = "Dell",
                    Stock = 5,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                },
                new Producto
                {
                    Id = 3,
                    CategoriaId = 2,
                    Nombre = "Honor 20 - Nuevo",
                    Precio = 34000.00M,
                    Estado = true,
                    Marca = "Huawei",
                    Stock = 10,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                },
                new Producto
                {
                    Id = 4,
                    CategoriaId = 2,
                    Nombre = "Lenovo L34 - Nuevo",
                    Precio = 40000.00M,
                    Estado = true,
                    Marca = "Lenovo",
                    Stock = 10,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                }
            );
        }
    }
}