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
            var medida = await _medidasRepository.GetAll();
            return Ok(medida);
        }
    
        [HttpGet("{MedidasId}")]
        public async Task<ActionResult<Medidas>> GetMedidas(int MedidasId)
        {
            var medidas = await _medidasRepository.Get(MedidasId);
            if(medidas == null)
                return NotFound();
    
            return Ok(medidas);
        }
        [HttpPost]
        public async Task<ActionResult> CreateMedidas(CreateMedidasDto createMedidasDto)
        {
            Medidas medidas = new()
            {
                MedidasId = createMedidasDto.MedidasId,
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
    
        [HttpDelete("{MedidasId}")]
        public async Task<ActionResult> DeleteMedidas(int MedidasId)
        {
            await _medidasRepository.Delete(MedidasId);
            return Ok();
        }
    
        [HttpPut("{MedidasId}")]
        public async Task<ActionResult> UpdateMedidas(int MedidasId, UpdateMedidasDto updateMedidasDto)
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