using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IDataContext _context;
        public StudentRepository(IDataContext context)
        {
        _context = context;
    
        }
        public async Task Add(Student student)
        {        
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }
    
        public async Task Delete(int StudentId)
        {
            var itemToRemove = await _context.Students.FindAsync(StudentId);
            if (itemToRemove == null)
                throw new NullReferenceException();
            
            // Borra el objeto
            _context.Students.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }
    
        public async Task<Student> Get(int StudentId)
        {
            return await _context.Students.FindAsync(StudentId);
        }
    
        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _context.Students.ToListAsync();
        }
    
        public async Task Update(Student student)
        {
            var itemToUpdate = await _context.Students.FindAsync(student.StudentId);
            if (itemToUpdate == null)
                throw new NullReferenceException();
            itemToUpdate.StudentName = student.StudentName;
            itemToUpdate.ParentName = student.ParentName ;
            itemToUpdate.PhoneNumber = student.PhoneNumber ;
            itemToUpdate.City = student.City ;
            await _context.SaveChangesAsync();
    
        }

    }
}