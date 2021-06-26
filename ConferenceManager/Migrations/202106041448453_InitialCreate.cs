namespace ConferenceManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
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
            
            CreateTable(
                "dbo.Conferences",
                c => new
                    {
                        ConferenceId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Location_AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ConferenceId)
                .ForeignKey("dbo.Addresses", t => t.Location_AddressId, cascadeDelete: true)
                .Index(t => t.Location_AddressId);
            
            CreateTable(
                "dbo.Registrations",
                c => new
                    {
                        RegistrationId = c.Int(nullable: false, identity: true),
                        ParticipantId = c.Int(nullable: false),
                        ConferenceId = c.Int(nullable: false),
                        RegistrationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RegistrationId)
                .ForeignKey("dbo.Conferences", t => t.ConferenceId, cascadeDelete: true)
                .ForeignKey("dbo.Participants", t => t.ParticipantId, cascadeDelete: true)
                .Index(t => t.ParticipantId)
                .Index(t => t.ConferenceId);
            
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        ParticipantId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 60),
                        LastName = c.String(nullable: false, maxLength: 60),
                        Email = c.String(nullable: false),
                        Phone = c.String(),
                        Address = c.String(),
                        ProfessionalTitle = c.Int(),
                        JobTitle = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ParticipantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Registrations", "ParticipantId", "dbo.Participants");
            DropForeignKey("dbo.Registrations", "ConferenceId", "dbo.Conferences");
            DropForeignKey("dbo.Conferences", "Location_AddressId", "dbo.Addresses");
            DropIndex("dbo.Registrations", new[] { "ConferenceId" });
            DropIndex("dbo.Registrations", new[] { "ParticipantId" });
            DropIndex("dbo.Conferences", new[] { "Location_AddressId" });
            DropTable("dbo.Participants");
            DropTable("dbo.Registrations");
            DropTable("dbo.Conferences");
            DropTable("dbo.Addresses");
        }
    }
}
