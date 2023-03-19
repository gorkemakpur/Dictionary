namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_test4 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Admins", "AdminRoleID");
            AddForeignKey("dbo.Admins", "AdminRoleID", "dbo.AdminRoles", "AdminRoleID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Admins", "AdminRoleID", "dbo.AdminRoles");
            DropIndex("dbo.Admins", new[] { "AdminRoleID" });
        }
    }
}
