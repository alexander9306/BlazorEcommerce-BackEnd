using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Almacen
{
    class Producto
    {
        public int id { get; set; }
        [Required]
        public int categoria_id { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre no debe de tener más de 50 caracteres, ni menos de 3 caracteres.")]
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public bool estado { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "La marca no debe de tener más de 50 caracteres, ni menos de 3 caracteres.")]
        public string marca { get; set; }
        [Required]
        public int stock { get; set; }
        [StringLength(256)]
        public string descripcion { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        public Categoria categoria { get; set; }
        public ProductoFoto foto { get; set; }
    }
}
