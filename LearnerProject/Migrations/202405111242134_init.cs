namespace LearnerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "ClassroomId", "dbo.Classrooms");
            DropIndex("dbo.Courses", new[] { "ClassroomId" });
            DropColumn("dbo.Courses", "ClassroomId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "ClassroomId", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "ClassroomId");
            AddForeignKey("dbo.Courses", "ClassroomId", "dbo.Classrooms", "ClassroomId", cascadeDelete: true);
        }
    }
}
