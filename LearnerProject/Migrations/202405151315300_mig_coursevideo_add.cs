namespace LearnerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_coursevideo_add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseVideos",
                c => new
                    {
                        CourseVideoId = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        VideoNumber = c.Int(nullable: false),
                        VideoUrl = c.String(),
                    })
                .PrimaryKey(t => t.CourseVideoId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseVideos", "CourseId", "dbo.Courses");
            DropIndex("dbo.CourseVideos", new[] { "CourseId" });
            DropTable("dbo.CourseVideos");
        }
    }
}
