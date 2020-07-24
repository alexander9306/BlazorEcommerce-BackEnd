namespace Sistema.Web.Datos.Mapping.Usuario
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Sistema.Web.Entidades.Usuario;

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