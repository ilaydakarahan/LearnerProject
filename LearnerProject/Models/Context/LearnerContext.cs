using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LearnerProject.Models.Context
{
    public class LearnerContext : DbContext
    {
        //pluralize : tekil olan şeyi çoğul hale getirir.
        public DbSet<About> Abouts { get; set; } //yani bu sınıfı sql tarafına çopul olarak yansıtırız,karışmasınlar diye        
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseRegister> CourseRegisters { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<CourseVideo> CourseVideos { get; set; }
    }
}