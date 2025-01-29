using Microsoft.EntityFrameworkCore;
using NIA_4_CRM.Models;
using System.Numerics;

namespace NIA_4_CRM.Data
{
    public class CrmContext : DbContext 
    {
        public CrmContext(DbContextOptions<CrmContext> options)
             : base(options)
        {
        }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<IndustryType> IndustryTypes { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            
            * An Organization cannot be deleted if it has associated Members.
            * A Contact cannot be deleted if it has associated Members.
            * A MembershipType cannot be deleted if it has associated Members.
             
             */

            // Configure relationships and other settings here
            modelBuilder.Entity<Member>()
                .HasOne(m => m.Organization)
                .WithMany(o => o.Members)
                .HasForeignKey(m => m.OrganizationId)
                .OnDelete(DeleteBehavior.Restrict); // Restrict deletion if referenced

            modelBuilder.Entity<Member>()
               .HasOne(m => m.Contact)
               .WithMany(c => c.Members)
               .HasForeignKey(m => m.ContactID)
               .OnDelete(DeleteBehavior.Restrict); // Restrict deletion if referenced

            modelBuilder.Entity<Member>()
                .HasOne(m => m.MembershipType)
                .WithMany(mt => mt.Members)
                .HasForeignKey(m => m.MembershipTypeId)
                .OnDelete(DeleteBehavior.Restrict); // Restrict deletion if referenced

            // Configure unique indexes
            modelBuilder.Entity<Organization>()
                .HasIndex(o => o.OrgName)
                .IsUnique();

            modelBuilder.Entity<Organization>()
                .HasIndex(o => o.Website)
                .IsUnique();

           
        }
    }
}
