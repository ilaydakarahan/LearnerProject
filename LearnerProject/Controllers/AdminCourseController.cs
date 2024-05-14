using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class AdminCourseController : Controller
    {
        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            var values = context.Courses.ToList();
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
            List<SelectListItem> category = (from x in context.Categories.Where(x=>x.Status==true).ToList()  
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString()
                                             }).ToList();
            ViewBag.category = category;
            //ilişkili tablo olduğu için category tablosundaki değerleri böyle çağırıyoruz.
            //category'ler dropdown da geliyor(combobox gibi)
            return View();
        }
        [HttpPost]
        public ActionResult AddCourse(Course course)
        {
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

            var value=context.Courses.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateCourse(Course course)
        {
            var value = context.Courses.Find(course.CourseId);
            value.CourseName = course.CourseName;
            value.ImageUrl = course.ImageUrl;
            value.Description = course.Description;
            value.Price = course.Price;
            value.CategoryId= course.CategoryId;
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}