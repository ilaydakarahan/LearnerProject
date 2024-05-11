using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnerProject.Models.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        //her class bir tablo. Bunların birbiriyle ilişkili olması için alttaki gibi yazılır.
        //ıd olan hep üste yazılmalı.
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }  //VİRTUAL kelimesi sadece .net' de var. .net Core da yok

        public List<Review> Reviews { get; set; }
        public List<CourseRegister> CourseRegisters { get; set; }
    }
}