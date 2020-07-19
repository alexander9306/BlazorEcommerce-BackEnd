namespace Sistema.Web.Entidades.Usuario
{
    using System.Collections.Generic;

    public class Rol
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Estado { get; set; }

        public string Descripcion { get; set; }

        public ICollection<Administrador> Administradores { get; }
    }
}