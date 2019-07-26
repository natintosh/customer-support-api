using CustomerSupport.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSupport.Controllers
{
    public class ComplaintDBContext : DbContext
    {
        public ComplaintDBContext(DbContextOptions options) : base(options)
        {
        }

        protected ComplaintDBContext()
        {
        }

        public DbSet<Complaint> Complaint { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) { }
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Complaint>(entity =>
            {
                entity.Property(e => e.Id)
                .HasColumnName("Id");

                entity.Property(e => e.CustomerName)
                .IsRequired()
                .HasMaxLength(105)
                .HasColumnName("CustomerName")
                .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnName("PhoneNumber")
                .IsUnicode(false);

                entity.Property(e => e.EmailAddress)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("EmailAddress")
                .IsUnicode(false);

                entity.Property(e => e.Description)
                .IsRequired()
                .HasColumnName("Description")
                .IsUnicode(false);

                entity.Property(e => e.TicketNumber)
                .IsRequired()
                .HasMaxLength(12)
                .HasColumnName("TicketNumber")
                .IsUnicode(false);

                entity.Property(e => e.CompanyUnit)
                .IsRequired()
                .HasMaxLength(1)
                .HasColumnName("CompanyUnit");

                entity.Property(e => e.Resolved)
                .HasColumnName("Resolved");
            });
        }
    }
}
