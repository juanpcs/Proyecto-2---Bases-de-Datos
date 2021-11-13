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
    [Route("api/Nutricionista")]
    public class NutricionistaController: ControllerBase
    {
    

        private readonly INutricionistaRepository _nutricionistaRepository;
        public NutricionistaController(INutricionistaRepository nutricionistaRepository)
        {
        _nutricionistaRepository = nutricionistaRepository;
        }
    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nutricionista>>> GetNutricionista()
        {
            var nutricionistas = await _nutricionistaRepository.GetAll();
            return Ok(nutricionistas);
        }
    
        [HttpGet("{Correo_electronico}")]
        public async Task<ActionResult<Nutricionista>> GetNutricionista(string Correo_electronico)
        {
            var nutricionista = await _nutricionistaRepository.Get(Correo_electronico);
            if(nutricionista == null)
                return NotFound();
    
            return Ok(nutricionista);
        }
        [HttpPost]
        public async Task<ActionResult> CreateNutricionista(CreateNutricionistaDto createNutricionistaDto)
        {
            Nutricionista nutricionista = new()
            {
                Correo_electronico = createNutricionistaDto.Correo_electronico,
                Cedula = createNutricionistaDto.Cedula,
                Nombre = createNutricionistaDto.Nombre,
                Apellido1 = createNutricionistaDto.Apellido1,
                Apellido2 = createNutricionistaDto.Apellido2,
                Direccion = createNutricionistaDto.Direccion,
                Fecha_nacimiento = createNutricionistaDto.Fecha_nacimiento,
                Foto = createNutricionistaDto.Foto,
                Contraseña = createNutricionistaDto.Contraseña,
                IMC = createNutricionistaDto.IMC,
                Peso = createNutricionistaDto.Peso,
                Tipo_cobro = createNutricionistaDto.Tipo_cobro,
                Numero_tarjeta = createNutricionistaDto.Numero_tarjeta,
                Codigo = createNutricionistaDto.Codigo,
            };
            await _nutricionistaRepository.Add(nutricionista);
            return Ok();
        }
    
        [HttpDelete("{Correo_electronico}")]
        public async Task<ActionResult> DeleteNutricionista(string Correo_electronico)
        {
            await _nutricionistaRepository.Delete(Correo_electronico);
            return Ok();
        }
    
        [HttpPut("{Correo_electronico}")]
        public async Task<ActionResult> UpdateNutricionista(string Correo_electronico, UpdateNutricionistaDto updateNutricionistaDto)
        {
            Nutricionista nutricionista = new()
            {
                Nombre = updateNutricionistaDto.Nombre,
                Apellido1 = updateNutricionistaDto.Apellido1,
                Apellido2 = updateNutricionistaDto.Apellido2,
                Direccion = updateNutricionistaDto.Direccion,
                Foto = updateNutricionistaDto.Foto,
                Contraseña = updateNutricionistaDto.Contraseña,
                IMC = updateNutricionistaDto.IMC,
                Peso = updateNutricionistaDto.Peso,
                Tipo_cobro = updateNutricionistaDto.Tipo_cobro,
                Numero_tarjeta = updateNutricionistaDto.Numero_tarjeta,
                Codigo = updateNutricionistaDto.Codigo,
            };
            
    
            await _nutricionistaRepository.Update(nutricionista);
            return Ok();
    
        }
        
    }
}