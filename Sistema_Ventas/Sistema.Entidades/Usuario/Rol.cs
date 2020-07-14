namespace Sistema.Entidades.Usuario
{
    using System.Collections.Generic;

    public class Rol
    {
        public Rol(string nombre, string estado, string descripcion, ICollection<Administrador> administradores)
        {
            Nombre = nombre;
            Estado = estado;
            Descripcion = descripcion;
            Administradores = administradores;
        }

        public string Nombre { get; set; }

        public string Estado { get; set; }

        public string Descripcion { get; set; }

        public ICollection<Administrador> Administradores { get; set; }
    }
}