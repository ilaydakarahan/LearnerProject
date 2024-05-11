using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnerProject.Models.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string NameSurname { get; set; }
        public string UserName { get; set;}
        public string Password { get; set;}
        public List<Review> Reviews { get; set; }
        public List<CourseRegister> CourseRegisters { get;}
    }
}