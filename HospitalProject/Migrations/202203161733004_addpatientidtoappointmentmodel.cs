namespace HospitalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpatientidtoappointmentmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointments", "Id");
            AddForeignKey("dbo.Appointments", "Id", "dbo.Patients", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "Id", "dbo.Patients");
            DropIndex("dbo.Appointments", new[] { "Id" });
            DropColumn("dbo.Appointments", "Id");
        }
    }
}
