namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_test3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminRoleID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "AdminRoleID");
        }
    }
}
