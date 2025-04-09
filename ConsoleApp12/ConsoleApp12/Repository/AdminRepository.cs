using ConsoleApp12.Interface;
using ConsoleApp12.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12.Repository
{
    class AdminRepository : IStudentrepostory
    {
        bool IStudentrepostory.AddStudent(Student student)
        {
            throw new NotImplementedException();
        }

        List<Student> IStudentrepostory.getstudents()
        {
            throw new NotImplementedException();
        }
    }
}
