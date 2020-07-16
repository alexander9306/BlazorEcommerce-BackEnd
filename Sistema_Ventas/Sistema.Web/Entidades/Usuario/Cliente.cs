namespace Sistema.Web.Entidades.Usuario
{
    using System;
    using Sistema.Web.Entidades.Ordenes;

    public class Cliente
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public DateTime FechaNac { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public Carrito Carrito { get; set; }

        public Orden Orden { get; set; }
    }
}