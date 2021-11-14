using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace WebApi.Models
{
    public class Plan
    {   
        [Key]
        public string Nombre { get; set; }
        public string NCorreo_electronico { get; set; }

    }
}