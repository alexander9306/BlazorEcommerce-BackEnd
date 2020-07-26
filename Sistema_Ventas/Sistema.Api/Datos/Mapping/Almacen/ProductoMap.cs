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
                    Nombre = "Iphone 7 - Usado",
                    Precio = 27000.00M,
                    Estado = true,
                    Marca = "Apple",
                    Stock = 15,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                },
                new Producto
                {
                    Id = 2,
                    CategoriaId = 1,
                    Nombre = "Iphone 7 - Nuevo",
                    Precio = 34000.00M,
                    Estado = true,
                    Marca = "Apple",
                    Stock = 5,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                },
                new Producto
                {
                    Id = 3,
                    CategoriaId = 2,
                    Nombre = "Lenovo N10 - Nuevo",
                    Precio = 34000.00M,
                    Estado = true,
                    Marca = "Lenovo",
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