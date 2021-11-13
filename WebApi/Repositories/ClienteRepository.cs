using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IDataContext _context;
        public ClienteRepository(IDataContext context)
        {
        _context = context;
    
        }
        public async Task Add(Cliente cliente)
        {        
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }
    
        public async Task Delete(string Correo_electronico)
        {
            var itemToRemove = await _context.Clientes.FindAsync(Correo_electronico);
            if (itemToRemove == null)
                throw new NullReferenceException();
            
            // Borra el objeto
            _context.Clientes.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }
    
        public async Task<Cliente> Get(string Correo_electronico)
        {
            return await _context.Clientes.FindAsync(Correo_electronico);
        }
    
        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _context.Clientes.ToListAsync();
        }
    
        public async Task Update(Cliente cliente)
        {
            var itemToUpdate = await _context.Clientes.FindAsync(cliente.Correo_electronico);
            if (itemToUpdate == null)
                throw new NullReferenceException();
            itemToUpdate.Nombre = cliente.Nombre;
            itemToUpdate.Apellido1 = cliente.Apellido1 ;
            itemToUpdate.Apellido2 = cliente.Apellido2 ;
            itemToUpdate.Pais = cliente.Pais ;
            itemToUpdate.Foto = cliente.Foto ;
            itemToUpdate.Contraseña = cliente.Contraseña ;
            itemToUpdate.IMC = cliente.IMC ;
            itemToUpdate.Peso_actual = cliente.Peso_actual ;
            itemToUpdate.Peso = cliente.Peso ;
            itemToUpdate.Consumo_calorias = cliente.Consumo_calorias ;
            itemToUpdate.NCorreo_electronico = cliente.NCorreo_electronico ;
            itemToUpdate.Pnombre = cliente.Pnombre ;
            await _context.SaveChangesAsync();
    
        }

    }
}