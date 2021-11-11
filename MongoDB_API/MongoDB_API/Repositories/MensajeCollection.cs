using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDB_API.Repositories
{
    public class MensajeCollection : IMensajeCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Mensaje> Collection;

        public MensajeCollection()
        {
            Collection = _repository.db.GetCollection<Mensaje>("Mensajes");
        }

        public async Task DeleteMensaje(string id)
        {
            //Creamos el filtro que lo que hace es igualar el id que obtenemos por parametro con el id en la database 
            var filter = Builders<Mensaje>.Filter.Eq(s => s.Id, new ObjectId(id));
            //Se le pide a la representación de la colección que borre uno segun esa condicion anterior
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<Mensaje>> GetAllMensajes()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }
        /*
        public async Task<Mensaje> GetMensajeById(string id)
        {
            return await Collection.FindAsync(
                new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }
        */
        public async Task<List<Mensaje>> GetMensajesByPaciente(string correo_paciente)
        {
            return await Collection.FindAsync(new BsonDocument { { "CorreoPaciente", correo_paciente} }).Result.ToListAsync();
        }

        public async Task InsertMensaje(Mensaje mensaje)
        {
            await Collection.InsertOneAsync(mensaje);
        }

        public async Task UpdateMensaje(Mensaje mensaje)
        {
            var filter = Builders<Mensaje>
                .Filter
                .Eq(s => s.Id, mensaje.Id);
            //Reemplaza lo que encuentre el filtro anterior por el mensaje que se está enviando
            await Collection.ReplaceOneAsync(filter, mensaje);
        }
    }
}
