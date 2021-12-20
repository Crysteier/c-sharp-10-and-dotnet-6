using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static System.Console;


namespace WorkingWithEFCore
{
    public class Northwind : DbContext
    {
        //these properties map to tables in the database
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (ProjectConstants.Databaseprovider.Equals("SQLite"))
            {
                string path = Path.Combine(Environment.CurrentDirectory, "Northwind.db");
                Console.WriteLine("never gonna use this shit");
            }
            else
            {
                string connection = "Data Source=.;Initial Catalog=Northwind;Integrated Security=true;MultipleActiveResultSets=true;";
                optionsBuilder.UseSqlServer(connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // example of using Fluent API instead of attributes
            // to limit the length of a category name to 15
            modelBuilder.Entity<Category>()
                .Property(category => category.CategoryName)
                .IsRequired()
                .HasMaxLength(15);

            if (ProjectConstants.Databaseprovider == "SQLite")
            {
                // added to "fix" the lack of decimal support in SQLite
                modelBuilder.Entity<Product>()
                .Property(product => product.Cost)
                .HasConversion<double>();
            }
        }
    }
}
