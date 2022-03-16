namespace HospitalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeStaffID : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Staffs");
            DropColumn("dbo.Staffs", "Id");
            AddColumn("dbo.Staffs", "SID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Staffs", "SID");
        }
        
        public override void Down()
        {

            DropPrimaryKey("dbo.Staffs");
            DropColumn("dbo.Staffs", "SID");
            AddColumn("dbo.Staffs", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Staffs", "Id");
        }
    }
}
