namespace HospitalProject.Migrations
{
    using HospitalProject.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HospitalProject.Data.HospitalProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HospitalProject.Data.HospitalProjectContext context)
        {
            context.Patients.AddOrUpdate(x => x.PID,
                new Patient() {PID = 1, FName = "Jenny", LName = "Dcruz", Address = "1698 Albion road", Contact = 9059812239, DOB = new DateTime(1999, 12, 22) }
                );

            context.Staffs.AddOrUpdate(x => x.SID,
                new Staff() { SID = 1, FName = "Hardi", LName = "Hemantkumar", DOB = new DateTime(2000, 04, 29), Contact = 9930911456, DID = "ER" }
                );
        }
    }
}
