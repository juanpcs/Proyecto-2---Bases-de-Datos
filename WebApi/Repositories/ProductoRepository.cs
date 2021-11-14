using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly IDataContext _context;
        public ProductoRepository(IDataContext context)
        {
        _context = context;
    
        }
        public async Task Add(Producto producto)
        {        
            _context.PRODUCTO.Add(producto);
            await _context.SaveChangesAsync();
        }
    
        public async Task Delete(decimal Codigo_barras)
        {
            var itemToRemove = await _context.PRODUCTO.FindAsync(Codigo_barras);
            if (itemToRemove == null)
                throw new NullReferenceException();
            
            // Borra el objeto
            _context.PRODUCTO.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }
    
        public async Task<Producto> Get(decimal Codigo_barras)
        {
            return await _context.PRODUCTO.FindAsync(Codigo_barras);
        }
    
        public async Task<IEnumerable<Producto>> GetAll()
        {
            return await _context.PRODUCTO.ToListAsync();
        }
    
        public async Task Update(Producto producto)
        {
            var itemToUpdate = await _context.PRODUCTO.FindAsync(producto.Codigo_barras);
            if (itemToUpdate == null)
                throw new NullReferenceException();
            itemToUpdate.Nombre = producto.Nombre;
            itemToUpdate.Codigo_barras = producto.Codigo_barras ;
            itemToUpdate.Estado = producto.Estado ;
            itemToUpdate.Descripcion = producto.Descripcion ;
            itemToUpdate.Porcion = producto.Porcion ;
            itemToUpdate.Energia = producto.Energia ;
            itemToUpdate.Grasa = producto.Grasa;
            itemToUpdate.Sodio = producto.Sodio ;
            itemToUpdate.Carbohidratos = producto.Carbohidratos ;
            itemToUpdate.Proteina = producto.Proteina ;
            itemToUpdate.Calcio = producto.Calcio ;
            itemToUpdate.Hierro = producto.Hierro ;
            itemToUpdate.Vitaminas = producto.Vitaminas ;
            itemToUpdate.ACorreo_electronico = producto.ACorreo_electronico ;
            await _context.SaveChangesAsync();
    
        }

    }
}