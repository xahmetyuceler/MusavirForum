using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MüþavirForum.Models;

namespace MüþavirForum.Context
{
    public class DatabaseContext : DbContext
    {


        public DbSet<User> Users { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DatabaseContext()
        {
            Database.SetInitializer(new SampleDatabaseContextInitializer());

        }
    }



    public class SampleDatabaseContextInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
          
        }
    }
}
