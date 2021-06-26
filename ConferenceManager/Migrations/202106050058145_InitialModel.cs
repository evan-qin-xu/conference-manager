namespace ConferenceManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Papers",
                c => new
                    {
                        PaperId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        publisher = c.String(),
                        PublicationDate = c.DateTime(nullable: false),
                        AttendeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaperId);
            
            CreateTable(
                "dbo.PaperAttendees",
                c => new
                    {
                        Paper_PaperId = c.Int(nullable: false),
                        Attendee_ParticipantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Paper_PaperId, t.Attendee_ParticipantId })
                .ForeignKey("dbo.Papers", t => t.Paper_PaperId, cascadeDelete: true)
                .ForeignKey("dbo.Participants", t => t.Attendee_ParticipantId, cascadeDelete: true)
                .Index(t => t.Paper_PaperId)
                .Index(t => t.Attendee_ParticipantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PaperAttendees", "Attendee_ParticipantId", "dbo.Participants");
            DropForeignKey("dbo.PaperAttendees", "Paper_PaperId", "dbo.Papers");
            DropIndex("dbo.PaperAttendees", new[] { "Attendee_ParticipantId" });
            DropIndex("dbo.PaperAttendees", new[] { "Paper_PaperId" });
            DropTable("dbo.PaperAttendees");
            DropTable("dbo.Papers");
        }
    }
}
