using WebApplication13.Interface;
using WebApplication13.Models;

namespace WebApplication13.Repository
{
    public class AdminRepository : IStudentrepository
    {
        Student IStudentrepository.AddStudent(Student student)
        {
            throw new NotImplementedException();
        }

        List<Student> IStudentrepository.GetStudents()
        {
            throw new NotImplementedException();
        }
    }
}
