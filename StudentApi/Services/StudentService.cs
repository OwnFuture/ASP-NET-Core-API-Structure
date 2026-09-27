using StudentApi.Models;
using StudentApi.DTOs;

namespace StudentApi.Services
{
    public class StudentService : IStudentService
    {
        private readonly List<Student> _students = new()
        {
            new Student
            {
                Id = 1,
                Name = "Mithun",
                Email = "mithun@example.com",
                Department = "IIT"
            },
            new Student
            {
                Id = 2,
                Name = "John",
                Email = "john@example.com",
                Department = "Computer Science"
            }
        };

        public List<Student> GetAll()
        {
            return _students;
        }

        public Student? GetById(int id)
        {
            return _students.FirstOrDefault(s => s.Id == id);
        }

        public Student Create(CreateStudentDto dto)
        {
            int newId = _students.Count == 0 ? 1 : _students.Max(s => s.Id) + 1;

            Student student = new Student
            {
                Id = newId,
                Name = dto.Name,
                Email = dto.Email,
                Department = dto.Department
            };
            _students.Add(student);
            return student;
        }

        public bool Update(int id, UpdateStudentDto dto)
        {
            Student? student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return false;
            }
            student.Name = dto.Name;
            student.Email = dto.Email;
            student.Department = dto.Department;
            return true;
        }

        public bool Delete(int id)
        {
            Student? student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return false;
            }
            _students.Remove(student);
            return true;
        }
    }
}
