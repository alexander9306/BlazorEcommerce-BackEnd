namespace Sistema.Api.Entidades.Usuario
{
    using System;
    using Sistema.Api.Entidades.Ordenes;

    public class Cliente
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }

        public DateTime FechaNac { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Carrito Carrito { get; set; }

        public Orden Orden { get; set; }
    }
}