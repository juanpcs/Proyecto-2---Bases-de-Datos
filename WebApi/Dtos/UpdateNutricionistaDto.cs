using System;

namespace WebApi.Dtos
{
    public class UpdateNutricionistaDto
    {
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Direccion { get; set; }
        public byte[] Foto { get; set; }
        public string Contraseña { get; set; }
        public decimal IMC { get; set; }
        public int Peso { get; set; }
        public string Tipo_cobro { get; set; }
        public decimal Numero_tarjeta { get; set; }
        public decimal Codigo { get; set; }

    }
}