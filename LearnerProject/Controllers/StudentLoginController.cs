using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LearnerProject.Controllers
{
    public class StudentLoginController : Controller
    {
        LearnerContext context = new LearnerContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Student student)      //Öğrenci giriş yapma metodu
        {
            var values = context.Students.FirstOrDefault(x => x.UserName == student.UserName
                && x.Password == student.Password);
            if (values == null)
            {
                ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(values.UserName, false);
                Session["studentName"] = values.NameSurname;
                return RedirectToAction("Index", "StudentCourse");
            }
 
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Default");
        }
    }
}