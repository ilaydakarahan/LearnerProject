using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnerProject.Models.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Icon { get; set; }
        public bool Status { get; set; }
        public List<Course> Courses { get; set; }
        //bir kategorinin alt kursları olabilir.
    }
}