using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AplicacionMantenimiento.Models
{
    public class Alquiler
    {
        public int ID { get; set; }
        public String UserId { get; set; }
        [Required]
        [Index("VideoId", IsUnique = true)]
        public int VideoId { get; set; }
    }
}