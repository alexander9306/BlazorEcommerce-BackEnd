namespace Sistema.Shared.Entidades.Ordenes.Orden
{
    using System;

    public class OrdenViewModel
    {
        public int Id { get; set; }

        public string Cliente { get; set; }

        public int ClienteId { get; set; }

        public int CarritoId { get; set; }

        public double Latitud { get; set; }

        public double Longitud { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Estado { get; set; }

        public decimal Total { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
