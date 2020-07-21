namespace Sistema.Web.Models.Usuario.Cliente
{
    using System;

    public class ClienteViewModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public DateTime FechaNac { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdateAt { get; set; }
    }
}
