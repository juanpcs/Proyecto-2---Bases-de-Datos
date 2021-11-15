using System;

namespace WebApi.Dtos
{
    public class CreateMedidasDto
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