using StudentApi.Models;
using StudentApi.DTOs;

namespace StudentApi.Services
{
    public interface IStudentService
    {
        List<Student> GetAll();
        Student? GetById(int id);
        Student Create(CreateStudentDto dto);
        bool Update(int id, UpdateStudentDto dto);
        bool Delete(int id);
    }
}
