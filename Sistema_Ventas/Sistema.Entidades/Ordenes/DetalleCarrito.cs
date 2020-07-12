using Sistema.Entidades.Almacen;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Ordenes
{
    class DetalleCarrito
    {
        public int id { get; set; }
        [Required]
        public int carrito_id { get; set; }
        [Required]
        public int producto_id { get; set; }

        public Producto producto { get; set; }
        public Carrito carrito { get; set; }
    }
}
