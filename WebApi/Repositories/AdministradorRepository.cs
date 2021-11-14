using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class AdministradorRepository : IAdministradorRepository
    {
        private readonly IDataContext _context;
        public AdministradorRepository(IDataContext context)
        {
        _context = context;
    
        }
        public async Task Add(Administrador administrador)
        {        
            _context.ADMINISTRADOR.Add(administrador);
            await _context.SaveChangesAsync();
        }
    
        public async Task Delete(string Correo_electronico)
        {
            var itemToRemove = await _context.ADMINISTRADOR.FindAsync(Correo_electronico);
            if (itemToRemove == null)
                throw new NullReferenceException();
            
            // Borra el objeto
            _context.ADMINISTRADOR.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }
    
        public async Task<Administrador> Get(string Correo_electronico)
        {
            return await _context.ADMINISTRADOR.FindAsync(Correo_electronico);
        }
    
        public async Task<IEnumerable<Administrador>> GetAll()
        {
            return await _context.ADMINISTRADOR.ToListAsync();
        }
    
        public async Task Update(Administrador administrador)
        {
            var itemToUpdate = await _context.ADMINISTRADOR.FindAsync(administrador.Correo_electronico);
            if (itemToUpdate == null)
                throw new NullReferenceException();
            itemToUpdate.Nombre = administrador.Nombre;
            itemToUpdate.Apellido1 = administrador.Apellido1 ;
            itemToUpdate.Apellido2 = administrador.Apellido2 ;
            itemToUpdate.Direccion = administrador.Direccion ;
            itemToUpdate.Foto = administrador.Foto ;
            itemToUpdate.Contraseña = administrador.Contraseña ;

            await _context.SaveChangesAsync();
    
        }

    }
}