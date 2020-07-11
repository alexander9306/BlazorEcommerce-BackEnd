using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Almacen
{
    class ProductoFoto
    {
        public int id { get; set; }
        [Required]
        public int producto_id { get; set; }
        public byte[] foto { get; set; }
    }
}
