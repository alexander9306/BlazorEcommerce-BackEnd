namespace Sistema.Api.Datos.Mapping.Usuario
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Sistema.Api.Entidades.Usuario;
    using Sistema.Api.Helpers;

    public class AdministradorMap : IEntityTypeConfiguration<Administrador>
    {
        public void Configure(EntityTypeBuilder<Administrador> builder)
        {
            var passwordHelper = new PasswordHelper();
            passwordHelper.CrearPasswordHash("admin01", out var adminPass);

            builder.HasIndex(a => a.Email)
                .IsUnique();
            builder.HasIndex(a => a.Username)
                .IsUnique();
            builder.HasData(new Administrador
            {
                Id = 1,
                RolId = 1,
                UpdatedAt = DateTime.Now,
                CreatedAt = DateTime.Now,
                Estado = true,
                Email = "admin@gmail.com",
                Username = "admin01",
                PasswordHash = adminPass,
            });
        }
    }
}