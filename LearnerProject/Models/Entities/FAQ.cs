using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnerProject.Models.Entities
{
    public class FAQ
    {
        public int FAQId { get; set; }
        public string Question { get; set;}
        public string Answer { get; set;}
        public string ImageUrl { get; set;}
        public bool Status { get; set;}

    }
}