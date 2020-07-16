namespace Sistema.Web.Entidades.Ordenes
{
    using System;

    public class Orden
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }

        public int CarritoId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public double Latitud { get; set; }

        public double Longitud { get; set; }

        public string Email { get; set; }

        public string Direccion { get; set; }

        public int Telefono { get; set; }

        public Pedido Pedido { get; set; }

        public Pago Pago { get; set; }
    }
}
