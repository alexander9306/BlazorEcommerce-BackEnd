using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Ordenes
{
    class Pedido
    {
        public int id { get; set; }
        public DateTime created_at { get; set; }
        public bool estado { get; set; }
        public ICollection<Orden> orden { get; set; }
    }
}
