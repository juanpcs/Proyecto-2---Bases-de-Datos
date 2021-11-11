using MongoDB_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDB_API.Repositories
{
    public interface IMensajeCollection
    {
        Task InsertMensaje(Mensaje mensaje);
        Task UpdateMensaje(Mensaje mensaje);
        Task DeleteMensaje(string id);

        Task<List<Mensaje>> GetAllMensajes();
        /*
        Task<Mensaje> GetMensajeById(string id);
        */
        Task<List<Mensaje>> GetMensajesByPaciente(string correo_paciente);

    }
}
