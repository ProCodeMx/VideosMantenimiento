using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacionMantenimiento.Models
{
    public class Cliente
    {
        public enum Membresias
        {
            Normal,
            Gold
        }

        public string CodigoCliente { get; set; }
        public string Nombre { get; set; }
        public Membresias? Membresia { get; set; }
    }
}