namespace ListIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Registries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUser = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Chores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Ok = c.Boolean(nullable: false),
                        Registry_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Registries", t => t.Registry_Id)
                .Index(t => t.Registry_Id);
            
            CreateTable(
                "dbo.SubTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Ok = c.Boolean(nullable: false),
                        Chore_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chores", t => t.Chore_Id)
                .Index(t => t.Chore_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Chores", "Registry_Id", "dbo.Registries");
            DropForeignKey("dbo.SubTasks", "Chore_Id", "dbo.Chores");
            DropIndex("dbo.SubTasks", new[] { "Chore_Id" });
            DropIndex("dbo.Chores", new[] { "Registry_Id" });
            DropTable("dbo.SubTasks");
            DropTable("dbo.Chores");
            DropTable("dbo.Registries");
            DropTable("dbo.Customers");
        }
    }
}
