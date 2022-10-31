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

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
