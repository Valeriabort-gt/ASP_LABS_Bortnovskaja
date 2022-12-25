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
        public DbSet<Photo> photos { get; set; }
        public DbSet<BuildingPhoto> buildingPhotos { get; set; }
        public DbSet<RoomPhoto> roomPhotos { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new BuildingConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
            modelBuilder.ApplyConfiguration(new OrganizationConfiguration());
            modelBuilder.ApplyConfiguration(new RentConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new PhotoConfiguration());
            modelBuilder.ApplyConfiguration(new BuildingPhotoConfiguration());
            modelBuilder.ApplyConfiguration(new RoomPhotoConfiguration());
            modelBuilder.Entity<Rent>().HasOne(u => u.organization).WithMany(u => u.rents).HasForeignKey(u => u.organizationID);
            modelBuilder.Entity<Rent>().HasOne(u => u.room).WithMany(u => u.rents).HasForeignKey(u => u.roomID);
            modelBuilder.Entity<Room>().HasOne(u => u.building).WithMany(u => u.rooms).HasForeignKey(u => u.buildingID);
            modelBuilder.Entity<Invoice>().HasOne(u => u.organization).WithMany(u => u.invoices).HasForeignKey(u => u.organizationID); 
            modelBuilder.Entity<Invoice>().HasOne(u => u.employee).WithMany(u => u.invoices).HasForeignKey(u => u.employeeID); 
            modelBuilder.Entity<Invoice>().HasOne(u => u.room).WithMany(u => u.invoices).HasForeignKey(u => u.roomID);
            modelBuilder.Entity<BuildingPhoto>().HasOne(u => u.building).WithMany(u => u.buildingPhotos).HasForeignKey(u => u.buildingID);
            modelBuilder.Entity<BuildingPhoto>().HasOne(u => u.photo).WithMany(u => u.buildingPhotos).HasForeignKey(u => u.photoID);
            modelBuilder.Entity<RoomPhoto>().HasOne(u => u.room).WithMany(u => u.roomPhotos).HasForeignKey(u => u.roomID);
            modelBuilder.Entity<RoomPhoto>().HasOne(u => u.photo).WithMany(u => u.roomPhotos).HasForeignKey(u => u.photoID);
            base.OnModelCreating(modelBuilder);
        }
    }
}
