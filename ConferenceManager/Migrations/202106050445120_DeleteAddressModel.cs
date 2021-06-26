namespace ConferenceManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteAddressModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Conferences", "Location_AddressId", "dbo.Addresses");
            DropIndex("dbo.Conferences", new[] { "Location_AddressId" });
            AddColumn("dbo.Conferences", "Location", c => c.String(nullable: false));
            DropColumn("dbo.Conferences", "Location_AddressId");
            DropTable("dbo.Addresses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        State = c.String(),
                        Postcode = c.Byte(nullable: false),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.AddressId);
            
            AddColumn("dbo.Conferences", "Location_AddressId", c => c.Int(nullable: false));
            DropColumn("dbo.Conferences", "Location");
            CreateIndex("dbo.Conferences", "Location_AddressId");
            AddForeignKey("dbo.Conferences", "Location_AddressId", "dbo.Addresses", "AddressId", cascadeDelete: true);
        }
    }
}
