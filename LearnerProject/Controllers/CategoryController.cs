using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class CategoryController : Controller
    {
        LearnerContext context = new LearnerContext(); //codefirst ile yazılmış projelerde db çağırılmaz,oluşturduğumuz context nesnesiyle çağırılır entity
        public ActionResult Index()
        {
            var values = context.Categories.Where(x => x.Status == true).ToList(); //aktif olanlar listelensin sadece
            return View(values);
        }
        public ActionResult DeleteCategory(int id) //burda farklı olarak silme işlemi yapmıyoruz.aktifse gözüksün,pasifse gözükmesini yapıyoruz.
        {   //sil butonuna basınca tam olarak silinmiyor.
            var value = context.Categories.Find(id);
            value.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            category.Status = true;
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = context.Categories.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            var value = context.Categories.Find(category.CategoryId);
            value.CategoryName = category.CategoryName;
            value.Icon = category.Icon;
            value.Status = true;
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}