namespace HospitalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateStaffTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Staffs", "FName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Staffs", "FName", c => c.String(nullable: false));
        }
    }
}
