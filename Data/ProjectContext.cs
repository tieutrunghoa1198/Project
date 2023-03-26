using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Models;
namespace Project.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost,1433;Database=Ass2_PRN221.Data;Trusted_Connection=False;User ID=sa;Password=123456");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>().HasKey(sc => new { sc.ProductID, sc.OrderID });

            modelBuilder.Entity<OrderDetail>()
                .HasOne<Product>(sc => sc.Product)
                .WithMany(s => s.OrderDetails)
                .HasForeignKey(sc => sc.ProductID);


            modelBuilder.Entity<OrderDetail>()
                .HasOne<Order>(sc => sc.Order)
                .WithMany(s => s.OrderDetails)
                .HasForeignKey(sc => sc.OrderID);
        }
        public DbSet<Project.Models.Account> Account { get; set; }
        public DbSet<Project.Models.Supplier> Supplier { get; set; }
        public DbSet<Project.Models.Product> Product { get; set; }
        public DbSet<Project.Models.Order> Order { get; set; }
        public DbSet<Project.Models.Customer> Customer { get; set; }
        public DbSet<Project.Models.Category> Category { get; set; }
        public DbSet<Project.Models.OrderDetail> OrderDetail { get; set; }
    }
}
