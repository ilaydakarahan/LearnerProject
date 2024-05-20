namespace LearnerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_teacher_video_add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseVideos", "TeacherId", c => c.Int());
            CreateIndex("dbo.CourseVideos", "TeacherId");
            AddForeignKey("dbo.CourseVideos", "TeacherId", "dbo.Teachers", "TeacherId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseVideos", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.CourseVideos", new[] { "TeacherId" });
            DropColumn("dbo.CourseVideos", "TeacherId");
        }
    }
}
