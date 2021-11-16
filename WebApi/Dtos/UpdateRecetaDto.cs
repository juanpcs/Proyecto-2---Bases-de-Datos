using System;

namespace WebApi.Dtos
{
    public class UpdateRecetaDto
    {
        public decimal Descripcion { get; set; }
        public int Porcion { get; set; }
        public int Energia { get; set; }
        public int Grasa { get; set; }
        public int Sodio { get; set; }
        public int Carbohidratos { get; set; }
        public int Proteina { get; set; }
        public int Calcio { get; set; }
        public int Hierro { get; set; }
        public string Vitaminas { get; set; }
    }
}