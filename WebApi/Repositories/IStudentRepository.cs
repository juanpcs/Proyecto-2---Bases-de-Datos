using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;
using Microsoft.Extensions.Configuration;

namespace WebApi
{
    public interface IStudentRepository
    {
        Task<Student> Get(int StudentId);
        Task<IEnumerable<Student>> GetAll();
        Task Add(Student student);
        Task Delete(int StudentId);
        Task Update(Student student);           
    }
}