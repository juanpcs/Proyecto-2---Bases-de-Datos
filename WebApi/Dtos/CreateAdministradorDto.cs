using System;

namespace WebApi.Dtos
{
    public class CreateAdministradorDto
    {
        public string Correo_electronico { get; set; }
        public decimal Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Direccion { get; set; }
        public DateTime Fecha_nacimiento { get; set; }
        public byte[] Foto { get; set; }
        public string Contraseña { get; set; }
        
    }
}