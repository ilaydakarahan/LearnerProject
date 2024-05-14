using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class AdminLayoutController : Controller
    {
        // GET: AdminLayout
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult AdminLayoutHead()
        {
            return PartialView();
        }

        public PartialViewResult AdminLayoutSidebar()
        {
            return PartialView();
        }

        public PartialViewResult AdminLayoutNavbar()
        {
            return PartialView();
        }
        public PartialViewResult AdminLayoutFooter()
        {
            return PartialView();
        }
    }
    
}