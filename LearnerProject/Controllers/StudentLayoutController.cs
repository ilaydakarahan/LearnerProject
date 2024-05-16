using LearnerProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class StudentLayoutController : Controller
    {
        LearnerContext context=new LearnerContext();
        public ActionResult Index()
        {
            return View();
        }
    }
}