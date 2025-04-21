using System.Linq;
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

        public Student AddStudent(Student student)
        {
            _context.Students.Add(student); 
            _context.SaveChanges();
            return student;
        }
        public Student FindStudent(int id)
        {
            return _context.Students.Where(e => e.Id == id).FirstOrDefault();
        }

        public void UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }
    }
}
