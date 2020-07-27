namespace Sistema.Shared.Entidades.Usuario
{
    using System;

    public class Cliente
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public DateTime FechaNac { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
