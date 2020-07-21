namespace Sistema.Web.Models.Usuario.Administrador
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AdministradorViewModel
    {
        public int Id { get; set; }

        public string Rol { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public bool Estado { get; set; }

    }
}
/*reynaldo yunior*/