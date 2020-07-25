namespace Api.Datos.Mapping.Usuario
{
    using Api.Entidades.Usuario;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AdministradorMap : IEntityTypeConfiguration<Administrador>
    {
        public void Configure(EntityTypeBuilder<Administrador> builder)
        {
            builder.HasIndex(a => a.Email)
                .IsUnique();
            builder.HasIndex(a => a.Username)
                .IsUnique();
        }
    }
}