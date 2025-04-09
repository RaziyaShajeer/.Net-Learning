using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12.Model
{
    public class Student
    {
       public Student()
        {

        }
        public Student( string name, string email)
        {
          
            Name = name;
            Email = email;
        }
      
        public int Id { get; set; }

        public string Name { get; set; }
 
        public string Email { get; set; }
    }
}
