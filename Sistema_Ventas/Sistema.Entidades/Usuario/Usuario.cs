using Sistema.Entidades.Almacen;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Ordenes
{
    class Cliente
    {
        public int id { get; set; }

        public string email { get; set; }

        public byte[] password_hash { get; set; }
        

        public byte[] password_salt  { get; set; }

        public DateTime fecha_nac { get; set; }

        public DateTime created_at { get; set; }

        public DateTime update_at { get; set; }

        
    }
}