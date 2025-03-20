using collegeDb.Models;
using System;

namespace MyApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			CollegeContext context = new CollegeContext();	
			string ch;
			do
			{
				student st = new student();
				Console.WriteLine("Enter students Details");
				Console.WriteLine("Enter the name");
				st.Name = Console.ReadLine();
				Console.WriteLine("Enter the Address");
				st.Addresss = Console.ReadLine();
				Console.WriteLine("Enter the City");
				st.City = Console.ReadLine();
				context.Add(st);
				context.SaveChanges();
				Console.WriteLine("Do you Want to Continue y/n");
				ch = Console.ReadLine();

				Console.WriteLine("Displaying the student details");
				var studentlist = context.students.ToList();
				foreach (var std in studentlist)
				{
					Console.WriteLine("Id:{0}\nName:{1}\nAddress:{2}\nCity:{3}\n", std.Id, st.Name, st.Addresss, st.City);
					Console.WriteLine("--------------");
				}

				Console.WriteLine("Removing student");
				Console.WriteLine("enter the id to remove");
				var idToRemove = Convert.ToInt32(Console.ReadLine());
				var studToRemove = context.students.Where(e => e.Id == idToRemove).FirstOrDefault();
				if (studToRemove != null)
				{
					context.students.Remove(studToRemove);
					context.SaveChanges();
					Console.WriteLine("removed Successfully");
				}
			} while (ch != "n");
		}
	}
}
