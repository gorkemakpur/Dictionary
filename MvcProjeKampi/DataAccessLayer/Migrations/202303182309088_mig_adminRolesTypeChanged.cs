namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_adminRolesTypeChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AdminRoles", "AdminRoleType", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AdminRoles", "AdminRoleType", c => c.Int(nullable: false));
        }
    }
}
