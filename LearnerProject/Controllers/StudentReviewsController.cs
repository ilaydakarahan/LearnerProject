using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class StudentReviewsController : Controller
    {
        // GET: StudentReviews
        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            string studentName = Session["studentName"].ToString();
            var student = context.Students.Where(x => x.NameSurname == studentName).Select(x => x.StudentId).FirstOrDefault();
            var values= context.Reviews.Where(x=>x.StudentId==student).ToList();

            return View(values);
        }

        [HttpGet]
        public ActionResult AddReview()
        {
            var review=context.Courses.ToList();

            List<SelectListItem> courseList=(from y in review select new SelectListItem
            {
                Text=y.CourseName,
                Value=y.CourseId.ToString()
            }).ToList();
            ViewBag.course=courseList;
            return View();
        }

        [HttpPost]
        public ActionResult AddReview(Review review)
        {
            string studentName = Session["studentName"].ToString();
            review.StudentId = context.Students.Where(x => x.NameSurname == studentName).Select(x => x.StudentId).FirstOrDefault();
            context.Reviews.Add(review);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteReview(int id)
        {
            var value = context.Reviews.Find(id);
            context.Reviews.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateReview(int id)
        {
            var values = context.Courses.ToList();

            List<SelectListItem> courseList=(from x in values select new SelectListItem
            {
                Text= x.CourseName,
                Value=x.CourseId.ToString()
            }).ToList();
            ViewBag.course = courseList;

            var review=context.Reviews.Find(id);
            return View(review);

        }
        [HttpPost]
        public ActionResult UpdateReview(Review review)
        {
            string studentName = Session["studentName"].ToString();
            review.StudentId = context.Students.Where(x => x.NameSurname == studentName).Select(x => x.StudentId).FirstOrDefault();

            var value = context.Reviews.Find(review.ReviewId);
            value.CourseId= review.CourseId;
            value.ReviewValue=review.ReviewValue;
            value.Comment=review.Comment;
            value.StudentId=review.StudentId;

            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}