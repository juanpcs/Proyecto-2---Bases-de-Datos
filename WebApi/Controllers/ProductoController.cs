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
    [Route("api/Producto")]
    public class ProductoController: ControllerBase
    {
    

        private readonly IProductoRepository _productoRepository;
        public ProductoController(IProductoRepository productoRepository)
        {
        _productoRepository = productoRepository;
        }
    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProducto()
        {
            var productos = await _productoRepository.GetAll();
            return Ok(productos);
        }
    
        [HttpGet("{Codigo_barras}")]
        public async Task<ActionResult<Producto>> GetProducto(decimal Codigo_barras)
        {
            var producto = await _productoRepository.Get(Codigo_barras);
            if(producto == null)
                return NotFound();
    
            return Ok(producto);
        }
        [HttpPost]
        public async Task<ActionResult> CreateProducto(CreateProductoDto createProductoDto)
        {
            Producto producto = new()
            {
                Nombre = createProductoDto.Nombre,
                Codigo_barras = createProductoDto.Codigo_barras,
                Estado = createProductoDto.Estado,
                Descripcion = createProductoDto.Descripcion,
                Porcion = createProductoDto.Porcion,
                Energia = createProductoDto.Energia,
                Grasa = createProductoDto.Grasa,
                Sodio = createProductoDto.Sodio,
                Carbohidratos = createProductoDto.Carbohidratos,
                Proteina = createProductoDto.Proteina,
                Calcio = createProductoDto.Calcio,
                Hierro = createProductoDto.Hierro,
                Vitaminas = createProductoDto.Vitaminas,
                ACorreo_electronico = createProductoDto.ACorreo_electronico,
            };
            await _productoRepository.Add(producto);
            return Ok();
        }
    
        [HttpDelete("{Codigo_barras}")]
        public async Task<ActionResult> DeleteProducto(decimal Codigo_barras)
        {
            await _productoRepository.Delete(Codigo_barras);
            return Ok();
        }
    
        [HttpPut("{Codigo_barras}")]
        public async Task<ActionResult> UpdateProducto(string Codigo_barras, UpdateProductoDto updateProductoDto)
        {
            Producto producto = new()
            {
                Nombre = updateProductoDto.Nombre,
                Codigo_barras = updateProductoDto.Codigo_barras,
                Estado = updateProductoDto.Estado,
                Descripcion = updateProductoDto.Descripcion,
                Porcion = updateProductoDto.Porcion,
                Energia = updateProductoDto.Energia,
                Grasa = updateProductoDto.Grasa,
                Sodio = updateProductoDto.Sodio,
                Carbohidratos = updateProductoDto.Carbohidratos,
                Proteina = updateProductoDto.Proteina,
                Calcio = updateProductoDto.Calcio,
                Hierro = updateProductoDto.Hierro,
                Vitaminas = updateProductoDto.Vitaminas,
                ACorreo_electronico = updateProductoDto.ACorreo_electronico,
            };
            
    
            await _productoRepository.Update(producto);
            return Ok();
    
        }
        
    }
}