namespace ListIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedCustomers : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Customers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
