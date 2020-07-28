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
                    CategoriaId = 2,
                    Nombre = "Laptop Dell Latitude E6540",
                    Precio = 30000.00M,
                    Estado = true,
                    Marca = "Dell",
                    Descripcion = "Dell Latitude E6540 – Full HD – Core i5 4th Gen – 16GB RAM – 500GB – Teclado Numérico",
                    Stock = 15,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                },
                new Producto
                {
                    Id = 2,
                    CategoriaId = 2,
                    Nombre = "LAPTOP ACER PREDATOR",
                    Precio = 44000.00M,
                    Estado = true,
                    Marca = "Acer",
                    Descripcion = "LAPTOP ACER PREDATOR CORE I7",
                    Stock = 5,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                },
                new Producto
                {
                    Id = 3,
                    CategoriaId = 1,
                    Nombre = " BLU G70",
                    Precio = 7000.00M,
                    Estado = true,
                    Marca = "BLU",
                    Descripcion = null,
                    Stock = 10,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                },
                new Producto
                {
                    Id = 4,
                    CategoriaId = 2,
                    Nombre = "Laptop Asus Q301L",
                    Precio = 25000.00M,
                    Estado = true,
                    Marca = "Asus",
                    Descripcion = "Laptop Asus Q301L – Intel Core i5 - 4200u – 8GB RAM – 500GB – Pantalla Touch – Teclado Iluminado – Ultra Liviana",
                    Stock = 10,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                },
                new Producto
                {
                    Id = 5,
                    CategoriaId = 2,
                    Nombre = "LAPTOP DELL G3 15 3579",
                    Precio = 45000.00M,
                    Estado = true,
                    Marca = "Dell",
                    Descripcion = "LAPTOP DELL G3 15 3579 8va GENERACION",
                    Stock = 15,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                },
                new Producto
                {
                    Id = 6,
                    CategoriaId = 2,
                    Nombre = "Laptop DELL Inspiron 14-3459",
                    Precio = 29000.00M,
                    Estado = true,
                    Marca = "DELL",
                    Descripcion = "Laptop DELL Inspiron 14-3459 – Intel Core i5-6200U Sexta Gen – 6GB RAM – 500GB HDD – AMD Radeon R5",
                    Stock = 20,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                },
                new Producto
                {
                    Id = 7,
                    CategoriaId = 1,
                    Nombre = "Google Pixel 4",
                    Precio = 10000.00M,
                    Estado = true,
                    Marca = "Google",
                    Descripcion = null,
                    Stock = 12,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                },
                new Producto
                {
                    Id = 8,
                    CategoriaId = 1,
                    Nombre = "Huawei Honor 20",
                    Precio = 15000.00M,
                    Estado = true,
                    Marca = "Huawei",
                    Descripcion = null,
                    Stock = 14,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                },
                new Producto
                {
                    Id = 9,
                    CategoriaId = 2,
                    Nombre = "LAPTOP DELL INSPIRON 15",
                    Precio = 35000.00M,
                    Estado = true,
                    Marca = "DELL",
                    Descripcion = "LAPTOP DELL INSPIRON 15 SILVER",
                    Stock = 10,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                },
                new Producto
                {
                    Id = 10,
                    CategoriaId = 2,
                    Nombre = "Laptop DELL INSPIRON 15-3558",
                    Precio = 40000.00M,
                    Estado = true,
                    Marca = "DELL",
                    Descripcion = "Laptop DELL INSPIRON 15-3558 – Intel Core i3 Quinta Generación – 4GB RAM – 1TB HDD",
                    Stock = 16,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                });
        }
    }
}