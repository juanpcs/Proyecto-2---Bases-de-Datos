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
    [Route("api/Medidas")]
    public class MedidasController: ControllerBase
    {
    

        private readonly IMedidasRepository _medidasRepository;
        public MedidasController(IMedidasRepository medidasRepository)
        {
        _medidasRepository = medidasRepository;
        }
    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medidas>>> GetMedidas()
        {
            var medidass = await _medidasRepository.GetAll();
            return Ok(medidass);
        }
    
        [HttpGet("{CCorreo_electronico}")]
        public async Task<ActionResult<Medidas>> GetMedidas(string CCorreo_electronico)
        {
            var medidas = await _medidasRepository.Get(CCorreo_electronico);
            if(medidas == null)
                return NotFound();
    
            return Ok(medidas);
        }
        [HttpPost]
        public async Task<ActionResult> CreateMedidas(CreateMedidasDto createMedidasDto)
        {
            Medidas medidas = new()
            {
                CCorreo_electronico = createMedidasDto.CCorreo_electronico,
                Fecha = createMedidasDto.Fecha,
                Cintura = createMedidasDto.Cintura,
                Cuello = createMedidasDto.Cuello,
                Caderas = createMedidasDto.Caderas,
                Musculo = createMedidasDto.Musculo,
                Grasa = createMedidasDto.Grasa,
               
            };
            await _medidasRepository.Add(medidas);
            return Ok();
        }
    
        [HttpDelete("{CCorreo_electronico}")]
        public async Task<ActionResult> DeleteMedidas(string CCorreo_electronico)
        {
            await _medidasRepository.Delete(CCorreo_electronico);
            return Ok();
        }
    
        [HttpPut("{CCorreo_electronico}")]
        public async Task<ActionResult> UpdateMedidas(string CCorreo_electronico, UpdateMedidasDto updateMedidasDto)
        {
            Medidas medidas = new()
            {
                Cintura = updateMedidasDto.Cintura,
                Cuello = updateMedidasDto.Cuello,
                Caderas = updateMedidasDto.Caderas,
                Musculo = updateMedidasDto.Musculo,
                Grasa = updateMedidasDto.Grasa,
            };
            
    
            await _medidasRepository.Update(medidas);
            return Ok();
    
        }
        
    }
}