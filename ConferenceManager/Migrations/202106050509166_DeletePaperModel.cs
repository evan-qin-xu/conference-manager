namespace ConferenceManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletePaperModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PaperAttendees", "Paper_PaperId", "dbo.Papers");
            DropForeignKey("dbo.PaperAttendees", "Attendee_ParticipantId", "dbo.Participants");
            DropIndex("dbo.PaperAttendees", new[] { "Paper_PaperId" });
            DropIndex("dbo.PaperAttendees", new[] { "Attendee_ParticipantId" });
            DropTable("dbo.Papers");
            DropTable("dbo.PaperAttendees");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PaperAttendees",
                c => new
                    {
                        Paper_PaperId = c.Int(nullable: false),
                        Attendee_ParticipantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Paper_PaperId, t.Attendee_ParticipantId });
            
            CreateTable(
                "dbo.Papers",
                c => new
                    {
                        PaperId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Publisher = c.String(),
                        PublicationDate = c.DateTime(nullable: false),
                        AttendeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaperId);
            
            CreateIndex("dbo.PaperAttendees", "Attendee_ParticipantId");
            CreateIndex("dbo.PaperAttendees", "Paper_PaperId");
            AddForeignKey("dbo.PaperAttendees", "Attendee_ParticipantId", "dbo.Participants", "ParticipantId", cascadeDelete: true);
            AddForeignKey("dbo.PaperAttendees", "Paper_PaperId", "dbo.Papers", "PaperId", cascadeDelete: true);
        }
    }
}
