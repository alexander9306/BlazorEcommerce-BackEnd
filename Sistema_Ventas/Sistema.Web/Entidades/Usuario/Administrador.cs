namespace Sistema.Web.Entidades.Usuario
{
    using System;

    public class Administrador
    {
        public int Id { get; set; }

        public int RolId { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public byte[] PasswordHash { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool Estado { get; set; }

        public Rol Rol { get; set; }
    }
}