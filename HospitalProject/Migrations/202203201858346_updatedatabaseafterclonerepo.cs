namespace HospitalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabaseafterclonerepo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Reason = c.String(),
                        PID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AID)
                .ForeignKey("dbo.Patients", t => t.PID, cascadeDelete: true)
                .Index(t => t.PID);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PID = c.Int(nullable: false, identity: true),
                        FName = c.String(),
                        LName = c.String(),
                        HC = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Address = c.String(),
                        Contact = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.PID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DID = c.Int(nullable: false, identity: true),
                        DName = c.String(),
                    })
                .PrimaryKey(t => t.DID);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        SID = c.Int(nullable: false, identity: true),
                        FName = c.String(),
                        LName = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Contact = c.Long(nullable: false),
                        DID = c.String(),
                    })
                .PrimaryKey(t => t.SID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UID = c.Int(nullable: false, identity: true),
                        FName = c.String(),
                        LName = c.String(),
                        Email = c.String(),
                        PWD = c.String(),
                    })
                .PrimaryKey(t => t.UID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "PID", "dbo.Patients");
            DropIndex("dbo.Appointments", new[] { "PID" });
            DropTable("dbo.Users");
            DropTable("dbo.Staffs");
            DropTable("dbo.Departments");
            DropTable("dbo.Patients");
            DropTable("dbo.Appointments");
        }
    }
}
