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
    [Route("api/Clientes")]
    public class ClienteController: ControllerBase
    {
    

        private readonly IClienteRepository _clienteRepository;
        public ClienteController(IClienteRepository clienteRepository)
        {
        _clienteRepository = clienteRepository;
        }
    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            var clientes = await _clienteRepository.GetAll();
            return Ok(clientes);
        }
    
        [HttpGet("{Correo_electronico}")]
        public async Task<ActionResult<Cliente>> GetCliente(string Correo_electronico)
        {
            var cliente = await _clienteRepository.Get(Correo_electronico);
            if(cliente == null)
                return NotFound();
    
            return Ok(cliente);
        }
        [HttpPost]
        public async Task<ActionResult> CreateCliente(CreateClienteDto createClienteDto)
        {
            Cliente cliente = new()
            {
                Correo_electronico = createClienteDto.Correo_electronico,
                Cedula = createClienteDto.Cedula,
                Nombre = createClienteDto.Nombre,
                Apellido1 = createClienteDto.Apellido1,
                Apellido2 = createClienteDto.Apellido2,
                Pais = createClienteDto.Pais,
                Fecha_nacimiento = createClienteDto.Fecha_nacimiento,
                Foto = createClienteDto.Foto,
                Contraseña = createClienteDto.Contraseña,
                IMC = createClienteDto.IMC,
                Peso_actual = createClienteDto.Peso_actual,
                Peso = createClienteDto.Peso,
                Consumo_calorias = createClienteDto.Consumo_calorias,
                NCorreo_electronico = createClienteDto.NCorreo_electronico,
                Pnombre = createClienteDto.Pnombre,
            };
            await _clienteRepository.Add(cliente);
            return Ok();
        }
    
        [HttpDelete("{Correo_electronico}")]
        public async Task<ActionResult> DeleteCliente(string Correo_electronico)
        {
            await _clienteRepository.Delete(Correo_electronico);
            return Ok();
        }
    
        [HttpPut("{Correo_electronico}")]
        public async Task<ActionResult> UpdateCliente(string Correo_electronico, UpdateClienteDto updateClienteDto)
        {
            Cliente cliente = new()
            {
                Nombre = updateClienteDto.Nombre,
                Apellido1 = updateClienteDto.Apellido1,
                Apellido2 = updateClienteDto.Apellido2,
                Pais = updateClienteDto.Pais,
                Foto = updateClienteDto.Foto,
                Contraseña = updateClienteDto.Contraseña,
                IMC = updateClienteDto.IMC,
                Peso_actual = updateClienteDto.Peso_actual,
                Peso = updateClienteDto.Peso,
                Consumo_calorias = updateClienteDto.Consumo_calorias,
                NCorreo_electronico = updateClienteDto.NCorreo_electronico,
                Pnombre = updateClienteDto.Pnombre,
            };
            
    
            await _clienteRepository.Update(cliente);
            return Ok();
    
        }
        
    }
}