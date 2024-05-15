using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class TeacherCourseController : Controller
    {
        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            string name = Session["teacherName"].ToString();        //giriş yapan kişinin session dan ismi çekip string formata çevirdim.
            var values = context.Courses.Where(x => x.Teacher.NameSurname == name).ToList();   //çektiğim isimi teacher tablosunda eşleşen isim değerlerini getir
            return View(values);
        }

        public ActionResult DeleteCourse(int id)
        {
            var value = context.Courses.Find(id);
            context.Courses.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddCourse()
        {
            List<SelectListItem> category = (from x in context.Categories.Where(x => x.Status == true).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString()
                                             }).ToList();
            ViewBag.category = category;
            return View();
        }
        [HttpPost]
        public ActionResult AddCourse(Course course)
        {
            string name = Session["teacherName"].ToString();

            course.TeacherId = context.Teachers.Where(x => x.NameSurname == name).Select(x =>   //giriş yapan kişi yeni kurs eklerken bir daha eğitmen
                                                                                                //olarak kendini seçmemesi için bu işlemi yaptık
                x.TeacherId).FirstOrDefault();
            context.Courses.Add(course);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCourse(int id)
        {

            List<SelectListItem> category = (from x in context.Categories.Where(x => x.Status == true).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString()
                                             }).ToList();
            ViewBag.category = category;

            var values=context.Courses.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateCourse(Course course)
        {
            var values = context.Courses.Find(course.CourseId);

            string name = Session["teacherName"].ToString();
            values.TeacherId = context.Teachers.Where(x => x.NameSurname == name).Select(x => 
            x.TeacherId).FirstOrDefault();


            values.CourseName=course.CourseName;
            values.CategoryId= course.CategoryId;
            values.Price= course.Price;
            values.ImageUrl= course.ImageUrl;
            values.Description= course.Description;

            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}