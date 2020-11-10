using CompartilharJogos.Domain.SharedGames;
using CompartilharJogos.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CompartilharJogos.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<ShareGame> SharedGames { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasKey(t => t.Id);
            modelBuilder.Entity<User>().HasMany(x => x.SharedGames).WithOne(x => x.User);

            modelBuilder.Entity<ShareGame>().HasKey(t => t.Id);
        }
        public async Task Commit()
        {
            await SaveChangesAsync();
        }
    }
}
