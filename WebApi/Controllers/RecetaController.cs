using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Models;
using WebApi.Repositories;
using System.Data;
using WebApi.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/Receta")]
    public class RecetaController: ControllerBase
    {
    

        private readonly IRecetaRepository _recetaRepository;
        public RecetaController(IRecetaRepository recetaRepository)
        {
        _recetaRepository = recetaRepository;
        }
    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receta>>> GetReceta()
        {
            var recetas = await _recetaRepository.GetAll();
            return Ok(recetas);
        }
    
        [HttpGet("{Nombre}")]
        public async Task<ActionResult<Receta>> GetReceta(string Nombre)
        {
            var receta = await _recetaRepository.Get(Nombre);
            if(receta == null)
                return NotFound();
    
            return Ok(receta);
        }
        [HttpPost]
        public async Task<ActionResult> CreateReceta(CreateRecetaDto createRecetaDto)
        {
            Receta receta = new()
            {
                Nombre = createRecetaDto.Nombre,
                Descripcion = createRecetaDto.Descripcion,
                Porcion = createRecetaDto.Porcion,
                Energia = createRecetaDto.Energia,
                Grasa = createRecetaDto.Grasa,
                Sodio = createRecetaDto.Sodio,
                Carbohidratos = createRecetaDto.Carbohidratos,
                Proteina = createRecetaDto.Proteina,
                Calcio = createRecetaDto.Calcio,
                Hierro = createRecetaDto.Hierro,
                Vitaminas = createRecetaDto.Vitaminas,
                CCorreo_electronico = createRecetaDto.CCorreo_electronico,
            };
            await _recetaRepository.Add(receta);
            return Ok();
        }

        [HttpPost("sp")]
        public async Task Post([FromBody] Receta receta)
        {
            await _recetaRepository.spAddReceta(receta);
        }
    
        [HttpDelete("{Nombre}")]
        public async Task<ActionResult> DeleteReceta(string Nombre)
        {
            await _recetaRepository.Delete(Nombre);
            return Ok();
        }
    
        [HttpPut("{Nombre}")]
        public async Task<ActionResult> UpdateReceta(string Nombre, UpdateRecetaDto updateRecetaDto)
        {
            Receta receta = new()
            {
                Descripcion = updateRecetaDto.Descripcion,
                Porcion = updateRecetaDto.Porcion,
                Energia = updateRecetaDto.Energia,
                Grasa = updateRecetaDto.Grasa,
                Sodio = updateRecetaDto.Sodio,
                Carbohidratos = updateRecetaDto.Carbohidratos,
                Proteina = updateRecetaDto.Proteina,
                Calcio = updateRecetaDto.Calcio,
                Hierro = updateRecetaDto.Hierro,
                Vitaminas = updateRecetaDto.Vitaminas,
            };
            
    
            await _recetaRepository.Update(receta);
            return Ok();
        }


        /*
        public IActionResult GetAReceta() 
        {
            List<Receta> list;
            string sql = "EXEC dbo.GetProductosByEstado @Name, @Descripcion, @CCorreo_electronico";
            
            List<SqlParameter> parms = new List<SqlParameter> 
            {
                // Create parameter(s)    
                new SqlParameter { ParameterName = "@Name", Value = 706 },
                new SqlParameter { ParameterName = "@Descripcion", Value = 1500 },
                new SqlParameter { ParameterName = "@CCorreo_electronico", Value = 1500 }
            };
            
            list = _recetaRepository.FromSqlRaw<Receta>(sql, parms.ToArray()).ToList();
            
        
        }*/

    }
}