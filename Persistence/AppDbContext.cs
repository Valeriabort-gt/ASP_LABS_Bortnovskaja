using Microsoft.EntityFrameworkCore;
using Persistence.EntityConfigurations;
using Domain;
using Application.Interfaces;

namespace Persistence
{
    public class AppDbContext : DbContext, IDbContext
    {
        public DbSet<Employee> employees { get; set; }
        public DbSet<Building> buildings { get; set; }
        public DbSet<Invoice> invoices { get; set; }
        public DbSet<Organization> organizations { get; set; }
        public DbSet<Rent> rents { get; set; }
        public DbSet<Room> rooms { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rent>().ToTable("rent", "dbo");
            modelBuilder.Entity<Building>().ToTable("building", "dbo");
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new BuildingConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
            modelBuilder.ApplyConfiguration(new OrganizationConfiguration());
            modelBuilder.ApplyConfiguration(new RentConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.Entity<Rent>().HasOne(u => u.organization).WithMany(u => u.rents).HasForeignKey(u => u.organizationID);
            modelBuilder.Entity<Rent>().HasOne(u => u.room).WithMany(u => u.rents).HasForeignKey(u => u.roomID);
            modelBuilder.Entity<Room>().HasOne(u => u.building).WithMany(u => u.rooms).HasForeignKey(u => u.buildingID);
            base.OnModelCreating(modelBuilder);
        }
    }
}
