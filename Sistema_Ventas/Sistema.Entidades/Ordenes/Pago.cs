using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Entidades.Ordenes
{
    class Pago
    {
        public int id { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime created_at { get; set; }
        public int Monto { get; set; }
        public bool Estado { get; set; }
        public ICollection<Orden> Orden { get; set; }
    }
}
