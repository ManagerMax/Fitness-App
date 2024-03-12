namespace Fitness.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmptyMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CaloriesBurnedPerMinute = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Exercises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActivityId = c.Int(nullable: false),
                        Start = c.DateTime(nullable: false),
                        Finish = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Activities", t => t.ActivityId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ActivityId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Weight = c.Double(nullable: false),
                        Height = c.Double(nullable: false),
                        Gender_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genders", t => t.Gender_Id)
                .Index(t => t.Gender_Id);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Proteins = c.Double(nullable: false),
                        Fats = c.Double(nullable: false),
                        Carbohydrates = c.Double(nullable: false),
                        Calories = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Meals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        userId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.userId, cascadeDelete: true)
                .Index(t => t.userId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Meals", "userId", "dbo.Users");
            DropForeignKey("dbo.Exercises", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "Gender_Id", "dbo.Genders");
            DropForeignKey("dbo.Exercises", "ActivityId", "dbo.Activities");
            DropIndex("dbo.Meals", new[] { "userId" });
            DropIndex("dbo.Users", new[] { "Gender_Id" });
            DropIndex("dbo.Exercises", new[] { "UserId" });
            DropIndex("dbo.Exercises", new[] { "ActivityId" });
            DropTable("dbo.Meals");
            DropTable("dbo.Foods");
            DropTable("dbo.Genders");
            DropTable("dbo.Users");
            DropTable("dbo.Exercises");
            DropTable("dbo.Activities");
        }
    }
}
