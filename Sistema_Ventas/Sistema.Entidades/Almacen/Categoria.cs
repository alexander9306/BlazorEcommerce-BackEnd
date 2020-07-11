using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Almacen
{
    class Categoria
    {
        public int id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre no debe de tener más de 50 caracteres, ni menos de 3 caracteres.")]
        public string nombre { get; set; }
        [StringLength(256)]
        public string descripcion { get; set; }
        public bool estado { get; set; }
        public DateTime created_at { get; set; }
        public DateTime update_at { get; set; }

        public ICollection<Producto> productos { get; set; }
    }
}
