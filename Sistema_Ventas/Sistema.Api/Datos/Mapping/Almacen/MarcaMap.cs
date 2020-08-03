namespace Sistema.Api.Datos.Mapping.Almacen
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Sistema.Api.Entidades.Almacen;

    public class MarcaMap : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            builder.HasIndex(c => c.Nombre)
                .IsUnique();
            builder.HasData(
                new Marca
                {
                    Id = 1,
                    Nombre = "Dell",
                    CreatedAt = DateTime.Now,
                },
                new Marca
                {
                    Id = 2,
                    Nombre = "Acer",
                    CreatedAt = DateTime.Now,
                }
                ,
                new Marca
                {
                    Id = 3,
                    Nombre = "BLU",
                    CreatedAt = DateTime.Now,
                },
                new Marca
                {
                    Id = 4,
                    Nombre = "Asus",
                    CreatedAt = DateTime.Now,
                },
                new Marca
                {
                    Id = 5,
                    Nombre = "Google",
                    CreatedAt = DateTime.Now,
                },
                new Marca
                {
                    Id = 6,
                    Nombre = "Huawei",
                    CreatedAt = DateTime.Now,
                }
                );
        }
    }
}