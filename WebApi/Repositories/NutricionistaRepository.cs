using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class NutricionistaRepository : INutricionistaRepository
    {
        private readonly IDataContext _context;
        public NutricionistaRepository(IDataContext context)
        {
        _context = context;
    
        }
        public async Task Add(Nutricionista nutricionista)
        {        
            _context.NUTRICIONISTA.Add(nutricionista);
            await _context.SaveChangesAsync();
        }
    
        public async Task Delete(string Correo_electronico)
        {
            var itemToRemove = await _context.NUTRICIONISTA.FindAsync(Correo_electronico);
            if (itemToRemove == null)
                throw new NullReferenceException();
            
            // Borra el objeto
            _context.NUTRICIONISTA.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }
    
        public async Task<Nutricionista> Get(string Correo_electronico)
        {
            return await _context.NUTRICIONISTA.FindAsync(Correo_electronico);
        }
    
        public async Task<IEnumerable<Nutricionista>> GetAll()
        {
            return await _context.NUTRICIONISTA.ToListAsync();
        }
    
        public async Task Update(Nutricionista nutricionista)
        {
            var itemToUpdate = await _context.NUTRICIONISTA.FindAsync(nutricionista.Correo_electronico);
            if (itemToUpdate == null)
                throw new NullReferenceException();
            itemToUpdate.Nombre = nutricionista.Nombre;
            itemToUpdate.Apellido1 = nutricionista.Apellido1 ;
            itemToUpdate.Apellido2 = nutricionista.Apellido2 ;
            itemToUpdate.Direccion = nutricionista.Direccion ;
            itemToUpdate.Foto = nutricionista.Foto ;
            itemToUpdate.Contraseña = nutricionista.Contraseña ;
            itemToUpdate.IMC = nutricionista.IMC ;
            itemToUpdate.Peso = nutricionista.Peso ;
            itemToUpdate.Tipo_cobro = nutricionista.Tipo_cobro ;
            itemToUpdate.Numero_tarjeta = nutricionista.Numero_tarjeta ;
            itemToUpdate.Codigo = nutricionista.Codigo ;
            await _context.SaveChangesAsync();
    
        }

    }
}