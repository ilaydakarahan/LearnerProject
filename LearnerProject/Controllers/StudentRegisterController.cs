using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class StudentRegisterController : Controller
    {
        LearnerContext context=new LearnerContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
            return RedirectToAction("Index","StudentLogin");
        }
    }
}