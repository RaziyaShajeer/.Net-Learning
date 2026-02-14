using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Identity.Client;
using Microsoft.VisualBasic;
using MVCSample.DTOs;
using MVCSample.Models;

namespace MVCSample.Controllers
{
    public class StudentController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public readonly IMapper _mapper;

		public StudentController(ApplicationDbContext context, IMapper mapper)
		{
			this.context = context;
			_mapper = mapper;
		}

		public IActionResult Index()
        {
            return View();
        }

        public String getname()
        {
            return "My name is Fara";
        }

        //[HttpGet]
        //public IActionResult ListStudent()
        //{
        //    var stdlist = context.Students.ToList();
        //    return View(stdlist);

        //}
        [HttpGet]
        public IActionResult Register() {
            return View();
        }
		public byte[] ConvertToBytes(IFormFile file)
		{
			using (var memoryStream = new MemoryStream())
			{
				file.CopyTo(memoryStream);
				return memoryStream.ToArray();
			}
		}

		[HttpPost]
        public IActionResult Register(StudentDTo std)
        {
            byte[] fileBytes;

            if (std.imagefile != null && std.imagefile.Length > 0)
            {
                fileBytes = ConvertToBytes(std.imagefile);
                // Now you can store `fileBytes` in DB or use it as needed
                var student = _mapper.Map<Student>(std);
                student.Image = fileBytes;


                context.Students.Add(student);
                context.SaveChanges();

                return View(std);
            }
            return View();  
		}

        //[HttpGet]
        //public IActionResult getdetails(int id)
        //{
        //   Student st = context.Students.Where(e => e.Id == id).FirstOrDefault();
        //    return View(st);
        //}

        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    Student st=context.Students.Where(e=>e.Id == id).FirstOrDefault();
        //    if (st != null) { 
        //        return View(st);
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}

        //[HttpPost]
        //public IActionResult Edit(Student updtdstd) {
        //    Student oldstd = context.Students.Where(e => e.Id == updtdstd.Id).FirstOrDefault();
        //    oldstd.Name=updtdstd.Name;
        //    oldstd.Description=updtdstd.Description;
        //    oldstd.emaiId=updtdstd.emaiId;
        //    oldstd.Password=updtdstd.Password;
        //    context.Students.Update(oldstd);
        //    context.SaveChanges();
        //    ViewBag.message = "Edited Successfully";
        //    return View();
        //}

        //[HttpGet]
        //public IActionResult Delete(int id) { 
        //    Student st=context.Students.Where(e=>e.Id==id).FirstOrDefault();
        //    if (st != null) { 
        //        context.Students.Remove(st);
        //        context.SaveChanges();
        //        return RedirectToAction("ListStudent");
        //    }
        //    else
        //    {
        //        return RedirectToAction("ListStudent");
        //    }

        //}


        
    }
}