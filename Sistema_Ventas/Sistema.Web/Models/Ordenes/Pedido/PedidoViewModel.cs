namespace Sistema.Web.Models.Ordenes.Orden.Pedido
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PedidoViewModel
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public int OrdenId { get; set; }

        public bool Estado { get; set; }
    }
}
