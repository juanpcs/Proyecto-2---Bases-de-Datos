using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class PlanRepository : IPlanRepository
    {
        private readonly IDataContext _context;
        public PlanRepository(IDataContext context)
        {
        _context = context;
    
        }
        public async Task Add(Plan plan)
        {        
            _context.PLAN_.Add(plan);
            await _context.SaveChangesAsync();
        }
    
        public async Task Delete(string Nombre)
        {
            var itemToRemove = await _context.PLAN_.FindAsync(Nombre);
            if (itemToRemove == null)
                throw new NullReferenceException();
            
            // Borra el objeto
            _context.PLAN_.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }
    
        public async Task<Plan> Get(string Nombre)
        {
            return await _context.PLAN_.FindAsync(Nombre);
        }
    
        public async Task<IEnumerable<Plan>> GetAll()
        {
            return await _context.PLAN_.ToListAsync();
        }
    
        public async Task Update(Plan plan)
        {
            var itemToUpdate = await _context.PLAN_.FindAsync(plan.Nombre);
            if (itemToUpdate == null)
                throw new NullReferenceException();
            itemToUpdate.Nombre = plan.Nombre;

            await _context.SaveChangesAsync();
    
        }

    }
}