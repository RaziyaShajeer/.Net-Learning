using ConsoleApp12.Interface;
using ConsoleApp12.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12.Repository
{
   
    public class StudentRepostory : IStudentrepostory

    {
        StudentContext _context = new StudentContext();
       
        public List<Student> getstudents()
        {
            //Constructor
            //Student student = new Student();
            //Student st1 = new Student(4, "uu", "uu@gmail.com");
           var std= _context.students.ToList();

            return std;
        }
        public bool AddStudent(Student student)
        {
          _context. students.Add(student);
            _context.SaveChanges();
            return true;
        }

    }
}
