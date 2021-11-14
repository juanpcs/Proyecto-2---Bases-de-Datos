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
    [Route("api/Plan")]
    public class PlanController: ControllerBase
    {
    

        private readonly IPlanRepository _planRepository;
        public PlanController(IPlanRepository planRepository)
        {
        _planRepository = planRepository;
        }
    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plan>>> GetPlan()
        {
            var plans = await _planRepository.GetAll();
            return Ok(plans);
        }
    
        [HttpGet("{Nombre}")]
        public async Task<ActionResult<Plan>> GetPlan(string Nombre)
        {
            var plan = await _planRepository.Get(Nombre);
            if(plan == null)
                return NotFound();
    
            return Ok(plan);
        }
        [HttpPost]
        public async Task<ActionResult> CreatePlan(CreatePlanDto createPlanDto)
        {
            Plan plan = new()
            {
                Nombre = createPlanDto.Nombre,
                NCorreo_electronico = createPlanDto.NCorreo_electronico,
                
            };
            await _planRepository.Add(plan);
            return Ok();
        }
    
        [HttpDelete("{Nombre}")]
        public async Task<ActionResult> DeletePlan(string Nombre)
        {
            await _planRepository.Delete(Nombre);
            return Ok();
        }
    
        [HttpPut("{Nombre}")]
        public async Task<ActionResult> UpdatePlan(string Nombre, UpdatePlanDto updatePlanDto)
        {
            Plan plan = new()
            {
                NCorreo_electronico = updatePlanDto.NCorreo_electronico,
                
            };
            
    
            await _planRepository.Update(plan);
            return Ok();
    
        }
        
    }
}