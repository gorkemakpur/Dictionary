namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_adminRolesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminRoles",
                c => new
                    {
                        AdminRoleID = c.Int(nullable: false, identity: true),
                        AdminRoleType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdminRoleID);
            
            AddColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "AdminRole");
            DropTable("dbo.AdminRoles");
        }
    }
}
