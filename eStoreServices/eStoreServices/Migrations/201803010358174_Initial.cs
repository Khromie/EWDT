namespace eStoreServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patterns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.Int(nullable: false),
                        Temperature = c.String(),
                        Humidity = c.String(),
                        RealPower = c.String(),
                        ActivePower = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Patterns");
        }
    }
}
