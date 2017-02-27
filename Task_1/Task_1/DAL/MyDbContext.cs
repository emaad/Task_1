using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Task_1.Models;

namespace Task_1.DAL
{
    public class MyDbContext : DbContext
    {
        public DbSet<DevTest> DevTest { get; set; }
        public MyDbContext()
            : base("name=Task1DBContext")
        {
            Database.SetInitializer<MyDbContext>(new CreateDatabaseIfNotExists<MyDbContext>());

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MyDbContextInitializer());
            modelBuilder.Entity<DevTest>()
             .Property(c => c.ID)
             .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            base.OnModelCreating(modelBuilder);
        }


        public class MyDbContextInitializer : DropCreateDatabaseIfModelChanges<MyDbContext>
        {
            protected override void Seed(MyDbContext dbContext)
            {
                // seed data

                base.Seed(dbContext);
            }
        }
    }
}