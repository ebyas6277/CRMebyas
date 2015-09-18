namespace CRMebyas.Migrations
{
    using CRMebyas.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CRMebyas.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CRMebyas.Models.ApplicationDbContext context)
        {
            context.Customers.AddOrUpdate(i => i.Email,
                new Customer { FirstName = "Harold", LastName = "Remus", Company = "Abraxas Petroleum Corporation", Email = "harold_remus@abrp.com", Address = "18803 Meisner Drive, San Antonio, Texas 78258", Phone = 2104904788 },
                new Customer { FirstName = "Susan", LastName = "Harrell", Company = "Abraxas Petroleum Corporation", Email = "susan_harrell@abrp.com", Address = "18803 Meisner Drive, San Antonio, Texas 78258", Phone = 2104904784 },
                new Customer { FirstName = "Gerald", LastName = "Thomas", Company = "Abraxas Petroleum Corporation", Email = "gerald_thomas@abrp.com", Address = "18803 Meisner Drive, San Antonio, Texas 78258", Phone = 2104904785 },
                new Customer { FirstName = "Timothy", LastName = "O'Brien", Company = "Gulfport Energy Corporation", Email = "tobrien@gulfen.com", Address = "14313 North May, Suite 100, Oklahoma City, OK 73134", Phone = 4058488807 },
                new Customer { FirstName = "Julie", LastName = "Slack", Company = "Gulfport Energy Corporation", Email = "jslack@gulfen.com", Address = "14313 North May, Suite 100, Oklahoma City, OK 73134", Phone = 4058488806 },
                new Customer { FirstName = "Glenn", LastName = "Preston", Company = "JP Oil Holdings, LLC", Email = "gpreston@jpoil.com", Address = "1604 W Pinhook Rd. Ste 300, Lafayette, LA 70508", Phone = 3372341170 },
                new Customer { FirstName = "Becky", LastName = "Huston", Company = "JP Oil Holdings, LLC", Email = "bhuston@jpoil.com", Address = "1604 W Pinhook Rd. Ste 300, Lafayette, LA 70508", Phone = 3372341171 }
            );
        }
    }
}
