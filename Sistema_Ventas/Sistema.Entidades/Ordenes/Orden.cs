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
        public int User_id { get; set; }
        [Required]
        public int Pedido_id { get; set; }
        [Required]
        public int Pago_id { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime created_at { get; set; }
        public DateTime update_at { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string Email { get; set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "La direccion no debe de tener más de 100 caracteres, ni menos de 3 caracteres.")]
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public Pedido Pedido { get; set; }
        public Pago Pago { get; set; }

    }
}
