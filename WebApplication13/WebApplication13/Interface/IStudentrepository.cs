using WebApplication13.Models;

namespace WebApplication13.Interface
{
    interface IStudentrepository
    {
        public List<Student> GetStudents();
        public Student AddStudent(Student student);

       
        public Student FindStudent(int id);


        public Student UpdateStudent(Student student);
        
    }
}
