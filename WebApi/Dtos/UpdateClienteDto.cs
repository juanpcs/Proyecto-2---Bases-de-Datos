using System;

namespace WebApi.Dtos
{
    public class UpdateClienteDto
    {
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Pais { get; set; }
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