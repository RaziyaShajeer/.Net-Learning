using System;
using schoolDb.Models;

namespace schoolDb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            string ch;

            do
            {
                Console.WriteLine("Choose An Operation : ");
                Console.WriteLine("1.Add Student");
                Console.WriteLine("2.Display Students");
                Console.WriteLine("3.Remove Student");
                Console.WriteLine("Enter your choice (1/2/3): ");
                ch = Console.ReadLine();

                switch (ch)
                {
                    case "1":

                        student st = new student();
                        Console.WriteLine("Enter Student Details");
                        Console.WriteLine("Enter the name : ");
                        st.Name = Console.ReadLine();
                        Console.WriteLine("Enter Address : ");
                        st.Addresss = Console.ReadLine();
                        Console.WriteLine("Enter the City");
                        st.City = Console.ReadLine();
                        context.Add(st);
                        context.SaveChanges();
                        Console.WriteLine("Student added successfully.");
                        break;

                    case "2":


                        Console.WriteLine("Display the Student Details");
                        Console.WriteLine("-------------------------------");
                        var studentlist = context.students.ToList();
                        foreach (var student in studentlist)
                        {
                            Console.WriteLine("Id:{0}\nName:{1}\nAddress:{2}\nCity{3}\n", student.Id, student.Name, student.Addresss, student.City);
                            Console.WriteLine("--------------------------------------------------");
                        }
                        break;
                    case "3":

                        Console.WriteLine("Removing student");
                        Console.WriteLine("enter the id to remove");
                        var IdtoRemove = Convert.ToInt32(Console.ReadLine());
                        var studToRemove = context.students.Where(e => e.Id == IdtoRemove).FirstOrDefault();
                        if (studToRemove != null)
                        {
                            context.students.Remove(studToRemove);
                            context.SaveChanges();
                            Console.WriteLine("Removed Successfully");
                        }
                        break;

                     case "4":

                        Console.WriteLine("Id to update : ");
                        var IdtoUpdate= Convert.ToInt32(Console.ReadLine());
                        var itemtoUpdate= context.students.Where(e => e.Id == IdtoUpdate).FirstOrDefault();
                        Console.WriteLine("Enter the new name : ");
                        itemtoUpdate.Name = Console.ReadLine();
                        context.students.Update(itemtoUpdate);
                        context.SaveChanges();
                        Console.WriteLine("Updated Successfully");

                        break;


                    default:
                        {
                            Console.WriteLine("Incorrect choice");
                        }
                        break;

                        Console.WriteLine("Do you Want to Continue ? y/n");
                        ch = Console.ReadLine();
                }
            }
            while (ch != "n");

        }
    }
}