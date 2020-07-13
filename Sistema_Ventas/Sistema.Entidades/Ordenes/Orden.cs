using Sistema.Entidades.Almacen;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Ordenes
{
    class Orden
    {
        public int id { get; set; }
        [Required]
        public int usuario_id { get; set; }
        [Required]
        public int pedido_id { get; set; }
        [Required]
        public int pago_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime update_at { get; set; }
        public double latitud { get; set; }
        public double longitud { get; set; }
        public string email { get; set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "La direccion no debe de tener más de 100 caracteres, ni menos de 3 caracteres.")]
        public string direccion { get; set; }
        public int telefono { get; set; }
        public Pedido pedido { get; set; }
        public Pago pago { get; set; }

    }
}
