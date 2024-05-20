using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnerProject.Models.Entities
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string NameSurname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Course> Courses { get; set; }
        public List<CourseVideo> CourseVideos { get; set; }
    }
}