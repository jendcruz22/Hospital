namespace HospitalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetimecolumnpropertyintoappointment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Appointments", "Time", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Appointments", "Time", c => c.DateTime(nullable: false));
        }
    }
}
