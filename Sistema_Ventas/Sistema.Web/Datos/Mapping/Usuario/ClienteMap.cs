namespace Api.Datos.Mapping.Usuario
{
    using Api.Entidades.Usuario;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasIndex(a => a.Email)
                .IsUnique();
        }
    }
}