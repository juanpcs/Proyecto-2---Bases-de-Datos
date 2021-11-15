using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace WebApi.Models
{
    public class Medidas
    {
        public int MedidasId { get; set; }
        public string CCorreo_electronico { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Cintura { get; set; }
        public decimal Cuello { get; set; }
        public decimal Caderas { get; set; }
        public int Musculo { get; set; }
        public int Grasa { get; set; }

    }
}