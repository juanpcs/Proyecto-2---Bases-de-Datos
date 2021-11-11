using Microsoft.AspNetCore.Mvc;
using MongoDB_API.Models;
using MongoDB_API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensajeController : Controller
    {
        private IMensajeCollection db = new MensajeCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllMensajes() {
            return Ok(await db.GetAllMensajes());
        }

        /*
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMensajeDetails(string id)
        {
            return Ok(await db.GetMensajeById(id));
        }
        */

        [HttpGet("{correo_paciente}")]
        public async Task<IActionResult> GetMensajesPaciente(string correo_paciente)
        {
            return Ok(await db.GetMensajesByPaciente(correo_paciente));
        }

        [HttpPost]
        public async Task<IActionResult> CreateMensaje([FromBody] Mensaje mensaje)
        {
            if (mensaje == null)
                return BadRequest();
            if (mensaje.CorreoPaciente == string.Empty)
            {
                ModelState.AddModelError("CorreoPaciente", "No se indica el correo del paciente");
            }

            await db.InsertMensaje(mensaje);

            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMensaje([FromBody] Mensaje mensaje, string id)
        {
            if (mensaje == null)
                return BadRequest();
            if (mensaje.CorreoPaciente == string.Empty)
            {
                ModelState.AddModelError("CorreoPaciente", "No se indica el nombre del paciente");
            }

            mensaje.Id = new MongoDB.Bson.ObjectId(id);
            await db.UpdateMensaje(mensaje);

            return Created("Created", true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMensaje(string id)
        {
            await db.DeleteMensaje(id);

            return NoContent(); //Success
        }


    }
}
