using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Company.Entities
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Report> Reports { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<UnitDocument> UnitDocuments { get; set; }
        public DbSet<UnitCard> UnitCards { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<WorkHour> WorkHours { get; set; }
        public DbSet<Reception> Receptions { get; set; }
        public DbSet<CompanyCard> CompanyCards { get; set; }
        public DbSet<Company> Companies { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;User Id = postgres; Password=postgres;Port=5432;Database=CompanyDom;");
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GameNumber_same;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // UnitDocument: composite key
            modelBuilder.Entity<UnitDocument>()
                .HasKey(ud => new { ud.UnitId, ud.DocumentId });

            // Report - DocumentType (many-to-many)
            modelBuilder.Entity<Report>()
                .HasMany(r => r.DocumentTypes)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            // DocumentType - Document (one-to-many)
            modelBuilder.Entity<DocumentType>()
                .HasMany(dt => dt.Documents)
                .WithOne(d => d.Type)
                .HasForeignKey(d => d.DocumentTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Unit - Document (many-to-many via UnitDocument)
            modelBuilder.Entity<Unit>()
                .HasMany(u => u.Documents)
                .WithMany()
                .UsingEntity<UnitDocument>(
                    j => j
                        .HasOne(ud => ud.Document)
                        .WithMany()
                        .HasForeignKey(ud => ud.DocumentId),
                    j => j
                        .HasOne(ud => ud.Unit)
                        .WithMany()
                        .HasForeignKey(ud => ud.UnitId),
                    j =>
                    {
                        j.HasKey(t => new { t.UnitId, t.DocumentId });
                    }
                );

            // Company - Unit (one-to-many)
            modelBuilder.Entity<Company>()
                .HasMany(c => c.Units)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            // CompanyCard - Phones, WorkHours, Receptions, Documents (one-to-many)
            modelBuilder.Entity<CompanyCard>()
                .HasMany(cc => cc.Phones)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<CompanyCard>()
                .HasMany(cc => cc.WorkHours)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<CompanyCard>()
                .HasMany(cc => cc.Receptions)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<CompanyCard>()
                .HasMany(cc => cc.Documents)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
