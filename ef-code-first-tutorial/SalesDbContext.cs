using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using Microsoft.EntityFrameworkCore;
using ef_code_first_tutorial.Models;

namespace ef_code_first_tutorial
{
    public class SalesDbContext : DbContext
    {
        // Tables accessible to DbContext
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }

        public SalesDbContext() { }

        public SalesDbContext(DbContextOptions<SalesDbContext> options)
          : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "server=localhost\\sqlexpress;" +
                                      "database=SalesDb2;" +
                                      "trusted_connection=true;" +
                                      "trustServerCertificate=true;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
