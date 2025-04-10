using WebApplication13.Interface;
using WebApplication13.Models;

namespace WebApplication13.Repository
{
    public class StudentRepository : IStudentrepository
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public List<Student> GetStudents()
        {
            var std= _context.Students.ToList();
            return std;
        }

        public bool AddStudent(Student student)
        {
            _context.Students.Add(student); 
            _context.SaveChanges();
            return true;
        }
    }
}
