using AccountingOrders.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingOrders.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<DepartmentModel>? Department { get; set; }

        public DbSet<OrderModel>? Order { get; set; }

        public DbSet<UserModel>? User { get; set; }

        public ApplicationContext()
        { 
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //ConfigurationManager.ConnectionStrings["ApplicationContext"].ConnectionString
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AccountingOrdersDB;Trusted_Connection=True;");
        }
    }
}