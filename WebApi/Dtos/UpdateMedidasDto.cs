using System;

namespace WebApi.Dtos
{
    public class UpdateMedidasDto
    {
        public decimal Cintura { get; set; }
        public decimal Cuello { get; set; }
        public decimal Caderas { get; set; }
        public int Musculo { get; set; }
        public int Grasa { get; set; }
    }
}