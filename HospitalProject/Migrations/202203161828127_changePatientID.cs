namespace HospitalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changePatientID : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Patients");
            DropColumn("dbo.Patients", "Id");
            AddColumn("dbo.Patients", "PID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Patients", "PID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Patients");
            DropColumn("dbo.Patients", "PID");
            AddColumn("dbo.Patients", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Patients", "Id");
        }
    }
}
