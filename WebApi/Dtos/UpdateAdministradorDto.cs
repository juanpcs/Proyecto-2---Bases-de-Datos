using System;

namespace WebApi.Dtos
{
    public class UpdateAdministradorDto
    {
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Direccion { get; set; }
        public byte[] Foto { get; set; }
        public string Contraseña { get; set; }
        
    }
}