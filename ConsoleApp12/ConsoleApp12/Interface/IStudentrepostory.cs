using ConsoleApp12.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12.Interface
{
    interface IStudentrepostory
    {
        public List<Student> getstudents();
        public bool AddStudent(Student student);
    }
}
