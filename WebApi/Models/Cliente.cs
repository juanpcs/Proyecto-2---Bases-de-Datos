using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace WebApi.Models
{
    public class Cliente
    {
        [Key]
        public string Correo_electronico { get; set; }
        public decimal Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Pais { get; set; }
        public DateTime Fecha_nacimiento { get; set; }
        public byte[] Foto { get; set; }
        public string Contraseña { get; set; }
        public decimal IMC { get; set; }
        public int Peso_actual { get; set; }
        public int Peso { get; set; }
        public int Consumo_calorias { get; set; }
        public string NCorreo_electronico { get; set; }
        public string Pnombre { get; set; }

    }
}