using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDB_API.Models
{
    public class Mensaje
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string CorreoPaciente { get; set; }
        public string CorreoNutricionista { get; set; }
        public string Emisor { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }

    }
}
