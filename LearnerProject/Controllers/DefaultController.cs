using LearnerProject.Models;
using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class DefaultController : Controller
    {
        LearnerContext context = new LearnerContext();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult DefaultCoursePartial()
        {
            ViewBag.v1 = context.Courses.Count();
            //yorumlar kısmını getiriyoruz bu sorguyla
            var values = context.Courses.Include(x => x.Reviews).OrderByDescending(x => x.CourseId).Take(3).ToList();
            return PartialView(values);
        }

        public ActionResult CourseDetail(int id)
        {
            var values = context.Courses.Find(id);
            var reviewList = context.Reviews.Where(x => x.CourseId == id).ToList();
            ViewBag.review = reviewList;  //yukarıdaki sorguda id'siyle gelen kursun yorumlarını viewbag'e taşıdık
            return View(values);
        }

        public PartialViewResult DefaultTestimonialPartial()
        {
            var values=context.Testimonials.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultFAQPartial()
        {
            //var values=context.FAQs.ToList();

            var values=context.FAQs.Where(x=>x.Status==true).OrderByDescending(x=>x.FAQId).Take(3).ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultCategoryPartial()
        {
            
            ViewBag.courseCount = context.CourseVideos.Where(x => x.Course.CourseId == 1).Count();

            var values = context.Categories.Where(x => x.Status == true).ToList();
            return PartialView(values);
        }
    }
}