using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplicacionMantenimiento.Models
{
    public class Video
    {
        public enum Tipos {
            Infantil = 0,
            Adolescentes = 1,
            Adultos = 2
        }
        public int ID { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        [Required]
        public Tipos? Tipo { get; set; }
        public string TiposAsString
        {
            get
            {
                return this.Tipo.ToString();
            }
            set
            {
                Tipo = (Tipos)Enum.Parse(typeof(Tipos), value, true);
            }
        }
    }       
}