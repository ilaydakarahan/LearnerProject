using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Message = LearnerProject.Models.Entities.Message;

namespace LearnerProject.Controllers
{
    public class ContactController : Controller
    {
        LearnerContext context=new LearnerContext();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult ContactInfo()
        {
            var values=context.Contacts.ToList();
            return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult SendMessage(Message message)
        {
            message.IsRead = false;
            context.Messages.Add(message);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}