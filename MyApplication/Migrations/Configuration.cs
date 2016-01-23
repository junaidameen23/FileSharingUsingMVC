namespace MyApplication.Migrations
{
    using MyApplication.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Data.Entity.Validation;
    using System.Diagnostics;

    internal sealed class Configuration : DbMigrationsConfiguration<MyApplication.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MyApplication.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            GenerateSalutation(context);
            GenerateRoles(context);
            //GenerateSystemAdmin(context);
        }

        private void GenerateSystemAdmin(ApplicationDbContext context)
        {
            var adminrole = context.Roles.Add(new ApplicationRole { Name = "Admin", Description = "Admin" });

            var newAdminUser = new ApplicationUser
            {
                SalutationId = 1,
                FirstName = "System",
                LastName = "Admin",
                Email = "admin@evis.com",
                PhoneNumber = "1234567890",
                UserName = "admin@evis.com",
                //DateOfBirth = new DateTime(1968, 07, 30),
                Address = "Abu Dhabi, UAE",
                SecurityStamp = System.Guid.NewGuid().ToString()
            };

            var passwordHash = new Microsoft.AspNet.Identity.PasswordHasher();
            var hashedPassword = passwordHash.HashPassword("evisadmin");
            newAdminUser.PasswordHash = hashedPassword;

            var adminUser = context.Users.Add(newAdminUser);

            adminUser.Roles.Add(
                new Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole
                {
                    UserId = adminUser.Id,
                    RoleId = adminrole.Id
                });

            context.Users.AddOrUpdate(adminUser);
        }

        private void GenerateSalutation(ApplicationDbContext context)
        {
            context.Salutation.Add(new Salutation { Name = "Ms.", Description = "Ms.", IsActive = true });
            context.Salutation.Add(new Salutation { Name = "Mr.", Description = "Mr.", IsActive = true });
            context.Salutation.Add(new Salutation { Name = "Dr.", Description = "Dr.", IsActive = true });
        }

        private static void GenerateRoles(ApplicationDbContext context)
        {
            context.Roles.Add(new ApplicationRole { Name = "Admin", Description = "Admin" });
            context.Roles.Add(new ApplicationRole { Name = "Supervisor", Description = "Supervisor" });
            context.Roles.Add(new ApplicationRole { Name = "Security ", Description = "Security " });
            context.Roles.Add(new ApplicationRole { Name = "Guest ", Description = "Guest " });
        }
    }
}
