namespace HospitalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changePatientID : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Patients");
            AddColumn("dbo.Patients", "PID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Patients", "PID");
            DropColumn("dbo.Patients", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Patients");
            DropColumn("dbo.Patients", "PID");
            AddPrimaryKey("dbo.Patients", "Id");
        }
    }
}
