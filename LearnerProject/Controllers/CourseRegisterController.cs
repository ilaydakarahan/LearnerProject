using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class CourseRegisterController : Controller
    {
        LearnerContext context = new LearnerContext();

        [HttpGet]
        public ActionResult Index()
        {
            var courseList = context.Courses.ToList();    //kurs tablosunu course list değişkenine atadık
            List<SelectListItem> courses = (from x in courseList        //courselist'den gelen kursları seç demek bu. 
                                            select new SelectListItem
                                            {
                                                Text = x.CourseName,        //text yazanda kurs ismi bize gözüksün diyoruz
                                                Value = x.CourseId.ToString()       //value olan da arkada çalışan eşleşecek değer
                                            }).ToList();
            ViewBag.course = courses;       //viewbag sayesinde yukarıda listelenen kurs isimleri ındex de dropdowna çekilecek

            return View();
        }

        [HttpPost]
        public ActionResult Index(CourseRegister courseRegister)
        {
            string student = Session["studentName"].ToString();     //sayfaya giriş yapan kişinin sessionlı kısım yani; adını al  =student' a ata. 
            courseRegister.StudentId = context.Students.Where(x => x.NameSurname == student).Select     //bunlar eşitse o isimli studentın id sini al, course registera ata.
                (x => x.StudentId).FirstOrDefault();
            context.CourseRegisters.Add(courseRegister);
            context.SaveChanges();
            return RedirectToAction("Index", "StudentCourse");
        }
    }
}