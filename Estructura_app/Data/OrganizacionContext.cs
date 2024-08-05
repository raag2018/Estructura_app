using Microsoft.EntityFrameworkCore;
using Estructura_app.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Estructura_app.Data{
    public class OrganizacionContext : DbContext{
        public OrganizacionContext(DbContextOptions<OrganizacionContext> options) : base(options) { }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            // Configuraciones adicionales
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerId);
            modelBuilder.Entity<Order>()
                .HasKey(o => o.OrderId);
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId);
            modelBuilder.Entity<Blog>()
                .Property(b => b.Url)
                .IsRequired();
        }
     }
}