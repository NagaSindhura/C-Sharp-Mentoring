namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBaseEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        MarksId = c.Int(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        SemisterId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MarksId)
                .ForeignKey("dbo.Semisters", t => t.SemisterId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .Index(t => t.StudentId)
                .Index(t => t.SemisterId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Semisters",
                c => new
                    {
                        SemisterId = c.Int(nullable: false, identity: true),
                        SemisterName = c.String(),
                    })
                .PrimaryKey(t => t.SemisterId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                        SemisterId = c.Int(nullable: false),
                        UniversityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.Semisters", t => t.SemisterId)
                .ForeignKey("dbo.Universities", t => t.UniversityId)
                .Index(t => t.SemisterId)
                .Index(t => t.UniversityId);
            
            CreateTable(
                "dbo.Universities",
                c => new
                    {
                        UniversityId = c.Int(nullable: false, identity: true),
                        UniversityName = c.String(),
                    })
                .PrimaryKey(t => t.UniversityId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                        SemisterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectId)
                .ForeignKey("dbo.Semisters", t => t.SemisterId)
                .Index(t => t.SemisterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Marks", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "SemisterId", "dbo.Semisters");
            DropForeignKey("dbo.Marks", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "UniversityId", "dbo.Universities");
            DropForeignKey("dbo.Students", "SemisterId", "dbo.Semisters");
            DropForeignKey("dbo.Marks", "SemisterId", "dbo.Semisters");
            DropIndex("dbo.Subjects", new[] { "SemisterId" });
            DropIndex("dbo.Students", new[] { "UniversityId" });
            DropIndex("dbo.Students", new[] { "SemisterId" });
            DropIndex("dbo.Marks", new[] { "SubjectId" });
            DropIndex("dbo.Marks", new[] { "SemisterId" });
            DropIndex("dbo.Marks", new[] { "StudentId" });
            DropTable("dbo.Subjects");
            DropTable("dbo.Universities");
            DropTable("dbo.Students");
            DropTable("dbo.Semisters");
            DropTable("dbo.Marks");
        }
    }
}
