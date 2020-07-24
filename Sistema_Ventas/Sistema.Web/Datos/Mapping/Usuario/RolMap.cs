namespace Sistema.Web.Datos.Mapping.Usuario
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Sistema.Web.Entidades.Usuario;

    public class RolMap : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.HasIndex(r => r.Nombre).IsUnique();
            builder.HasData(
                new Rol
                {
                    Id = 1,
                    Nombre = "Administrador",
                    Descripcion = "Acceso máximo del sistema.",
                },
                new Rol
                {
                    Id = 2,
                    Nombre = "Organizador",
                    Descripcion = "Acceso a las ordenes del sistema.",
                }
            );
        }
    }
}