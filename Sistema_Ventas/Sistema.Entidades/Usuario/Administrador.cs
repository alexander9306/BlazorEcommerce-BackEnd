using Sistema.Entidades.Almacen;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Ordenes
{
    class Administrador
    {
        public int id { get; set; }

        public string email { get; set; }

        public string username { get; set; }

        public byte[] password_hash { get; set; }

        public byte[] password_salt  { get; set; }

        public DateTime created_at { get; set; }

        public DateTime update_at { get; set; }

        public string estado {get; set;}

        
    }
}