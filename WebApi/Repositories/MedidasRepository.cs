using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class MedidasRepository : IMedidasRepository
    {
        private readonly IDataContext _context;
        public MedidasRepository(IDataContext context)
        {
        _context = context;
    
        }
        public async Task Add(Medidas medidas)
        {        
            _context.MEDIDAS.Add(medidas);
            await _context.SaveChangesAsync();
        }
    
        public async Task Delete(string CCorreo_electronico)
        {
            var itemToRemove = await _context.MEDIDAS.FindAsync(CCorreo_electronico);
            if (itemToRemove == null)
                throw new NullReferenceException();
            
            // Borra el objeto
            _context.MEDIDAS.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }
    
        public async Task<Medidas> Get(string CCorreo_electronico)
        {
            return await _context.MEDIDAS.FindAsync(CCorreo_electronico);
        }
    
        public async Task<IEnumerable<Medidas>> GetAll()
        {
            return await _context.MEDIDAS.ToListAsync();
        }
    
        public async Task Update(Medidas medidas)
        {
            var itemToUpdate = await _context.MEDIDAS.FindAsync(medidas.CCorreo_electronico);
            if (itemToUpdate == null)
                throw new NullReferenceException();
            itemToUpdate.Cintura = medidas.Cintura;
            itemToUpdate.Cuello = medidas.Cuello ;
            itemToUpdate.Caderas = medidas.Caderas ;
            itemToUpdate.Musculo = medidas.Musculo ;
            itemToUpdate.Grasa = medidas.Grasa ;

            await _context.SaveChangesAsync();
    
        }

    }
}