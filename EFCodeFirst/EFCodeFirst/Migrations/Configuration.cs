namespace EFCodeFirst.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EFCodeFirst.EF.EFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EFCodeFirst.EF.EFContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            for(int i=1; i <= 10; i++) 
            {
                context.Departments.AddOrUpdate(
                    new EF.Models.Department()
                    {
                        Name = Guid.NewGuid().ToString().Substring(0,5),
                    }
                    );
            }
            Random random = new Random();
            for(int i=1; i<=10; i++)
            {
                context.Students.AddOrUpdate(
                    new EF.Models.Student() 
                    {
                        Name=Guid.NewGuid().ToString().Substring(0,5),
                        DepartmentId=random.Next(1,11),
                        Cgpa=2.5f+(float)random.NextDouble()
                    });
            }
            for(int i=1;i<=10;i++)
            {
                context.Courses.AddOrUpdate(
                    new EF.Models.Course()
                    {
                        Name=Guid.NewGuid().ToString().Substring(0,5),
                        Description = Guid.NewGuid().ToString().Substring(0, 5),
                        OfferedBy = Guid.NewGuid().ToString().Substring(0, 5),
                        DepartmentId = random.Next(1, 11),
                    });
            }

        }
    }
}
