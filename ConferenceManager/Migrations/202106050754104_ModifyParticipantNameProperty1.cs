namespace ConferenceManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyParticipantNameProperty1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Participants", "FullName", c => c.String(nullable: false, maxLength: 60));
            DropColumn("dbo.Participants", "FirstName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Participants", "FirstName", c => c.String(nullable: false, maxLength: 60));
            DropColumn("dbo.Participants", "FullName");
        }
    }
}
