namespace Sistema.Shared.Entidades.Usuario.Cliente
{
    using System;

    public class ClienteViewModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public DateTime FechaNac { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
