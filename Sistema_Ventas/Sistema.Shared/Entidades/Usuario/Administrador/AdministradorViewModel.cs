namespace Sistema.Shared.Entidades.Usuario.Administrador
{
    using System;

    public class AdministradorViewModel
    {
        public int Id { get; set; }

        public string Rol { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool Estado { get; set; }

    }
}
