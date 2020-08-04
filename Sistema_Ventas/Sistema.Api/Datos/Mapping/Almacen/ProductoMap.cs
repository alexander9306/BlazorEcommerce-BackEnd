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
                    MarcaId = 1,
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
                    MarcaId = 2,
                    Descripcion = "LAPTOP ACER PREDATOR CORE I7",
                    Stock = 5,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                },
                new Producto
                {
                    Id = 3,
                    CategoriaId = 1,
                    Nombre = "BLU G70",
                    Precio = 7000.00M,
                    Estado = true,
                    MarcaId = 3,
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
                    MarcaId = 4,
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
                    MarcaId = 1,
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
                    MarcaId = 1,
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
                    MarcaId = 5,
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
                    MarcaId = 6,
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
                    MarcaId = 1,
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
                    MarcaId = 1,
                    Descripcion = "Laptop DELL INSPIRON 15-3558 – Intel Core i3 Quinta Generación – 4GB RAM – 1TB HDD",
                    Stock = 16,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                },
                new Producto
                {
                    Id = 11,
                    CategoriaId = 2,
                    Nombre = "Laptop Dell Latitude 3350",
                    Precio = 30000.00M,
                    Estado = true,
                    MarcaId = 1,
                    Descripcion = "Laptop Dell Latitude 3350 – Intel Core I5 Quinta Generacion 500GB - 6GB RAM",
                    Stock = 10,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                },
                new Producto
                {
                    Id = 12,
                    CategoriaId = 2,
                    Nombre = "Laptop Dell Latitude E5450",
                    Precio = 25000.00M,
                    Estado = true,
                    MarcaId = 1,
                    Descripcion = "Laptop Dell Latitude E5450 – i5 Quinta Generación – 8GB RAM – 500GB HDD",
                    Stock = 10,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                },
                new Producto
                {
                    Id = 13,
                    CategoriaId = 1,
                    Nombre = "Huawei Y7p",
                    Precio = 13000.00M,
                    Estado = true,
                    MarcaId = 6,
                    Descripcion = null,
                    Stock = 10,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                },
                new Producto
                {
                    Id = 14,
                    CategoriaId = 2,
                    Nombre = "Laptop Dell Ultrabook E7240",
                    Precio = 50000.00M,
                    Estado = true,
                    MarcaId = 1,
                    Descripcion = "Laptop Dell Ultrabook E7240 – 12GB Ram – Intel Core i5 – 128GB SSD",
                    Stock = 15,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                },
                new Producto
                {
                    Id = 15,
                    CategoriaId = 2,
                    Nombre = "Laptop HP 15-ba051wm",
                    Precio = 40000.00M,
                    Estado = true,
                    MarcaId = 10,
                    Descripcion = "Laptop HP 15-ba051wm – Pantalla Touch – Quad-Core A10-9600P – 8GB RAM – 1TB HDD",
                    Stock = 10,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                },
                new Producto
                {
                    Id = 16,
                    CategoriaId = 1,
                    Nombre = "iPhone 11 (128GB)",
                    Precio = 86000.00M,
                    Estado = true,
                    MarcaId = 7,
                    Descripcion = null,
                    Stock = 20,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                },
                new Producto
                {
                    Id = 17,
                    CategoriaId = 1,
                    Nombre = "iPhone 8 Plus 64GB",
                    Precio = 20000.00M,
                    Estado = true,
                    MarcaId = 7,
                    Descripcion = null,
                    Stock = 10,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                },
                new Producto
                {
                    Id = 18,
                    CategoriaId = 2,
                    Nombre = "Laptop HP 15-f387wm",
                    Precio = 40000.00M,
                    Estado = true,
                    MarcaId = 10,
                    Descripcion = "Laptop HP 15-f387wm – AMD A8-7410 – 500GB HDD – 4GB RAM – Radeon R5 – Pantalla Táctil – Teclado Numérico",
                    Stock = 15,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                },
                new Producto
                {
                    Id = 19,
                    CategoriaId = 1,
                    Nombre = "LG Aristo 5",
                    Precio = 15000.00M,
                    Estado = true,
                    MarcaId = 8,
                    Descripcion = null,
                    Stock = 10,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                },
                new Producto
                {
                    Id = 20,
                    CategoriaId = 1,
                    Nombre = "Samsung Galaxy A11",
                    Precio = 25000.00M,
                    Estado = true,
                    MarcaId = 9,
                    Descripcion = null,
                    Stock = 10,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                });
        }
    }
}