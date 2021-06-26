namespace ConferenceManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyParticipantNameProperty : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Participants", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Participants", "LastName", c => c.String(nullable: false, maxLength: 60));
        }
    }
}
