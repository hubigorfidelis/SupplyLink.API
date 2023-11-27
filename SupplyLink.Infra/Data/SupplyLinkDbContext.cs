using Microsoft.EntityFrameworkCore;
using SupplyLink.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyLink.Infra.Data
{
    public class SupplyLinkDbContext : DbContext

    {
        public SupplyLinkDbContext(DbContextOptions<SupplyLinkDbContext> options ) : base(options)
        { 

        }

       public DbSet<Client> Clients { get; set; }
       public DbSet<User> Users { get; set; }
       public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .ToTable("customer")
                .HasKey(c => c.Id);
               

            modelBuilder.Entity<Client>()
                 .Property(c => c.CreateAt)
                .HasColumnName("create_date");

            modelBuilder.Entity<Client>()
                 .Property(c => c.Document)
                .HasColumnName("document");

            modelBuilder.Entity<Client>()
                .Property(c => c.Login)
        .       HasColumnName("login");

            modelBuilder.Entity<Client>()
                .Property(c => c.Name)
                .HasColumnName("name");

            modelBuilder.Entity<Client>()
                .Property(c => c.Status)
                .HasColumnName("status");


            modelBuilder.Entity<User>()
                .ToTable("users")    
                .HasKey(u => u.Id);

            modelBuilder.Entity<Supplier>()
                .ToTable("suppliers")
                .HasKey(c => c.Id);

            modelBuilder.Entity<Supplier>()
                 .Property(c => c.CreateAt)
                .HasColumnName("create_date");
        }       
    }
}
