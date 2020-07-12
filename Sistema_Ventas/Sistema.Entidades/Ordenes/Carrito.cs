using Sistema.Entidades.Almacen;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Ordenes
{
    class Carrito
    {
        public int id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime update_at { get; set; }

        public ICollection<DetalleCarrito> detalles { get; set; }
    }
}
