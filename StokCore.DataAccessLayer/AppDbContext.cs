using Microsoft.EntityFrameworkCore;
using StokCore.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokCore.DataAccessLayer
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-EELQ0C13\\SQLEXPRESS; database=StokCoreDb; integrated security=true; TrustServerCertificate=True;");
                         
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);  // Virgülden sonra 2 basamak, toplam 18 rakam

            modelBuilder.Entity<Product>()
                .Property(p => p.Stock)
                .HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
       
    }
}
