using Microsoft.EntityFrameworkCore;
using Domain;

namespace Application.Interfaces
{
    public interface IDbContext
    {
        public DbSet<Employee> employees { get; set; }
        public DbSet<Building> buildings { get; set; }
        public DbSet<Invoice> invoices { get; set; }
        public DbSet<Organization> organizations { get; set; }
        public DbSet<Rent> rents { get; set; }
        public DbSet<Room> rooms { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Photo> photos { get; set; }
        public DbSet<BuildingPhoto> buildingPhotos { get; set; }
        public DbSet<RoomPhoto> roomPhotos { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        int SaveChanges();
    }
}
