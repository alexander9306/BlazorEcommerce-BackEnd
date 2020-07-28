namespace Sistema.Shared.Entidades.Usuario
{
    using System;

    public class Rol
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public bool Estado { get; set; }

        public string? Descripcion { get; set; }

    }
}