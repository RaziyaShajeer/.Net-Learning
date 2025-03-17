using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using Firstprgm;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        //Console.WriteLine("Enter your name : ");
        //string name = Console.ReadLine();
        //Console.WriteLine(name);

        //Student student1 = new Student();
        //Console.WriteLine("Enter name");
        //student1.Name = Console.ReadLine();
        //Console.WriteLine("Enter ur Id");
        //student1.Id =Convert.ToInt32( Console.ReadLine());
        //Console.WriteLine("Enter ur address");
        //student1.Address = Console.ReadLine();

        //Console.WriteLine("Name:{0} Address:{1} Id:{2}",student1.Name,student1.Address,student1.Id);


        //array in oops
        //Student[] students = new Student[4];

        //for (int i = 0; i < 3; i++)
        //{
        //    students[i] = new Student();//doubt
        //    Console.WriteLine("Enter name");
        //    students[i].Name = Console.ReadLine();
        //    Console.WriteLine("Enter ur Id");
        //    students[i].Id = Convert.ToInt32(Console.ReadLine());
        //    Console.WriteLine("Enter ur address");
        //    students[i].Address = Console.ReadLine();

        //}

        //Console.WriteLine("Student info");
        //foreach (Student student in students)
        //{
        //    Console.WriteLine("Name:{0} Id:{1} Id:{1} Address:{2}", student.Name, student.Id, student.Address);
        //}


        //using list

        List<Student> students = new List<Student>();
        Console.WriteLine("Enter how many students want to add : ");
        int numofstd =Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i <= numofstd; i++) {

            Student student = new Student();
            Console.WriteLine("ENter name: ");
            student.Name = Console.ReadLine();
            Console.WriteLine("Enter your Id");
            student.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your address");
            student.Address = Console.ReadLine();

            students.Add(student);

        }
        Console.WriteLine("Student info");

        foreach (Student student in students)
        {
            Console.WriteLine("Name:{0} Id:{1} Address:{2}",student.Name,student.Id,student.Address);
        }
    }
}