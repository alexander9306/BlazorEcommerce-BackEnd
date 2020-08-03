namespace Sistema.Api.Datos.Mapping.Almacen
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Sistema.Api.Entidades.Almacen;

    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasIndex(c => c.Nombre)
                .IsUnique();

            builder.HasData(
                new Categoria
                {
                    Id = 1,
                    Nombre = "Celulares",
                    Descripcion = "Celulares nuevos y usados.",
                    Estado = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Categoria
                {
                    Id = 2,
                    Nombre = "Computadoras",
                    Descripcion = "Tenemos computadoras de ultima generacion.",
                    Estado = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                });
        }
    }
}
