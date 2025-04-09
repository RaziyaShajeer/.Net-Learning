
using ConsoleApp12.Interface;
using ConsoleApp12.Model;
using ConsoleApp12.Repository;
using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IStudentrepostory _studentRepository = new StudentRepostory();

            Console.WriteLine("Hello World!");
            var input = "y";
            do
            {
                Console.WriteLine("1.Add 2.Display");
                Console.Write("Enter your choice");
                var choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Add");
                        Console.WriteLine("Enter Name");
                        var name = Console.ReadLine();
                        Console.WriteLine("Enter Email");
                        var Email = Console.ReadLine();
                      
                        Student st = new Student( name, Email);
                      var res= _studentRepository.AddStudent(st);
                       break;
                    case 2:
                        Console.WriteLine("List");
                        var list = _studentRepository.getstudents();
                        foreach (var item in list)
                        {
                            Console.WriteLine(item.Name);
                            Console.WriteLine(item.Email);
                            Console.WriteLine("-----------");

                        }
                        break;
                    default:
                        Console.WriteLine("Invalid");
                        break;







                }
                Console.WriteLine("Doyou want to continue Y/N");
                input = Console.ReadLine();
            } while (input != "N" || input != "n");
        }
    }
    }
        