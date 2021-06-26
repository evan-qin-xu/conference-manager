namespace ConferenceManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyConferenceTitleProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Conferences", "ConferenceTitle", c => c.String(nullable: false));
            DropColumn("dbo.Conferences", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Conferences", "Title", c => c.String(nullable: false));
            DropColumn("dbo.Conferences", "ConferenceTitle");
        }
    }
}
