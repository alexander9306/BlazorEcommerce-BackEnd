using Sistema.Entidades.Almacen;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Ordenes
{
    class Usuario
    {
        public int id { get; set; }

        [Required]
        [StringLength(20,ErrorMessage="Email/Username no debe tener más de 20 caracteres.")]
        public string email_username { get; set; }

        [Required]
        [StringLength(15,MinimumLength=8,ErrorMessage="La clave no debe tener más de 15 caracteres, ni menos de 8 caracteres.")]
        public string password { get; set; }

        [Required]
        public SeleccionTipo tipo { get; set; }
        public DateTime fecha_nac { get; set; }

        public enum SeleccionTipo
        {
            Administrador,
            Usuario
        }
    }
}