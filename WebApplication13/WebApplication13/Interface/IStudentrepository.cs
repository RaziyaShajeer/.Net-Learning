using WebApplication13.Models;

namespace WebApplication13.Interface
{
    interface IStudentrepository
    {
        public List<Student> GetStudents();
        public bool AddStudent(Student student);
    }
}
