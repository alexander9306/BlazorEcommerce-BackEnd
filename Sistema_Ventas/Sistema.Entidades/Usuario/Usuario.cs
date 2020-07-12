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
        [StringLength(20,ErrorMessage="Email no debe tener más de 20 caracteres.")]
        public string email { get; set; }

        [Required]
        [StringLength(10,ErrorMessage="Username no debe tener más de 10 caracteres.")]
        public string username { get; set; }

        [Required]
        [StringLength(15,MinimumLength=8,ErrorMessage="La clave no debe tener más de 15 caracteres, ni menos de 8 caracteres.")]
        public string password { get; set; }

        [Required]
        public string tipo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fecha_nac { get; set; }

        
    }
}