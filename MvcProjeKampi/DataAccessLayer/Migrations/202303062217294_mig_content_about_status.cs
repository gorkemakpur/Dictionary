namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_content_about_status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "AboutStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Headings", "HeadingStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Contents", "ContentStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contents", "ContentStatus");
            DropColumn("dbo.Headings", "HeadingStatus");
            DropColumn("dbo.Abouts", "AboutStatus");
        }
    }
}
