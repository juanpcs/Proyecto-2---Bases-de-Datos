using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MovilApi.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string BookName { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }
    }
}