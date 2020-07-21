namespace Sistema.Web.Entidades.Usuario
{
    using System.Collections.Generic;
    using System;

    public class RolViewModel
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public bool Estado { get; set; }

        public string? Descripcion { get; set; }
    }
}