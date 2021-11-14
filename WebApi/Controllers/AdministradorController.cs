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
    [Route("api/Administrador")]
    public class AdministradorController: ControllerBase
    {
    

        private readonly IAdministradorRepository _administradorRepository;
        public AdministradorController(IAdministradorRepository administradorRepository)
        {
        _administradorRepository = administradorRepository;
        }
    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Administrador>>> GetAdministrador()
        {
            var administradors = await _administradorRepository.GetAll();
            return Ok(administradors);
        }
    
        [HttpGet("{Correo_electronico}")]
        public async Task<ActionResult<Administrador>> GetAdministrador(string Correo_electronico)
        {
            var administrador = await _administradorRepository.Get(Correo_electronico);
            if(administrador == null)
                return NotFound();
    
            return Ok(administrador);
        }
        [HttpPost]
        public async Task<ActionResult> CreateAdministrador(CreateAdministradorDto createAdministradorDto)
        {
            Administrador administrador = new()
            {
                Correo_electronico = createAdministradorDto.Correo_electronico,
                Cedula = createAdministradorDto.Cedula,
                Nombre = createAdministradorDto.Nombre,
                Apellido1 = createAdministradorDto.Apellido1,
                Apellido2 = createAdministradorDto.Apellido2,
                Direccion = createAdministradorDto.Direccion,
                Fecha_nacimiento = createAdministradorDto.Fecha_nacimiento,
                Foto = createAdministradorDto.Foto,
                Contraseña = createAdministradorDto.Contraseña,
                
            };
            await _administradorRepository.Add(administrador);
            return Ok();
        }
    
        [HttpDelete("{Correo_electronico}")]
        public async Task<ActionResult> DeleteAdministrador(string Correo_electronico)
        {
            await _administradorRepository.Delete(Correo_electronico);
            return Ok();
        }
    
        [HttpPut("{Correo_electronico}")]
        public async Task<ActionResult> UpdateAdministrador(string Correo_electronico, UpdateAdministradorDto updateAdministradorDto)
        {
            Administrador administrador = new()
            {
                Nombre = updateAdministradorDto.Nombre,
                Apellido1 = updateAdministradorDto.Apellido1,
                Apellido2 = updateAdministradorDto.Apellido2,
                Direccion = updateAdministradorDto.Direccion,
                Foto = updateAdministradorDto.Foto,
                Contraseña = updateAdministradorDto.Contraseña,

            };
            
    
            await _administradorRepository.Update(administrador);
            return Ok();
    
        }
        
    }
}