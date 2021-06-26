namespace ConferenceManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConferenceTimeToConferenceModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Conferences", "ConferenceTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Conferences", "ConferenceTime");
        }
    }
}
