using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Nutricionista
    {
        [Key]
        public string Correo_electronico { get; set; }
        public decimal Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Direccion { get; set; }
        public DateTime Fecha_nacimiento { get; set; }
        public string Foto { get; set; }
        public string Contraseña { get; set; }
        public decimal IMC { get; set; }
        public int Peso { get; set; }
        public string Tipo_cobro { get; set; }
        public decimal Numero_tarjeta { get; set; }
        public decimal Codigo { get; set; }
        // Listado de clientes debido a la relacion 1 N
        //public List<Cliente> Clientes { get; set; }

    }
}