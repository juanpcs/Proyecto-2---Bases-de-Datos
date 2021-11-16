using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;



namespace WebApi.Repositories
{
    public class RecetaRepository : IRecetaRepository
    {
        private readonly IDataContext _context;
        public RecetaRepository(IDataContext context)
        {
        _context = context;
    
        }
        public async Task Add(Receta receta)
        {        
            _context.RECETA.Add(receta);
            await _context.SaveChangesAsync();
        }

        
    
        public async Task Delete(string Nombre)
        {
            var itemToRemove = await _context.RECETA.FindAsync(Nombre);
            if (itemToRemove == null)
                throw new NullReferenceException();
            
            // Borra el objeto
            _context.RECETA.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }
    
        public async Task<Receta> Get(string Nombre)
        {
            return await _context.RECETA.FindAsync(Nombre);
        }
    
    
        public async Task<IEnumerable<Receta>> GetAll()
        {
            return await _context.RECETA.ToListAsync();
        }
    
        public async Task Update(Receta receta)
        {
            var itemToUpdate = await _context.RECETA.FindAsync(receta.Nombre);
            if (itemToUpdate == null)
                throw new NullReferenceException();
            itemToUpdate.Descripcion = receta.Descripcion ;
            itemToUpdate.Porcion = receta.Porcion ;
            itemToUpdate.Energia = receta.Energia ;
            itemToUpdate.Grasa = receta.Grasa;
            itemToUpdate.Sodio = receta.Sodio ;
            itemToUpdate.Carbohidratos = receta.Carbohidratos ;
            itemToUpdate.Proteina = receta.Proteina ;
            itemToUpdate.Calcio = receta.Calcio ;
            itemToUpdate.Hierro = receta.Hierro ;
            itemToUpdate.Vitaminas = receta.Vitaminas ;
            await _context.SaveChangesAsync();
    
        }

    }
}