using Microsoft.EntityFrameworkCore;
using MusicManagementSystem.Models;

namespace MusicManagementSystem.Data
{
    public class ApiDbContext : DbContext
    {
        //Here We are passing the Connection String and Database Provider (Like MSSQL or MySQL Information)
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
            
        }

        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>().HasData(
                new Song
                {
                    Id = 1,
                    Title = "Nice",
                    Language = "English",
                    Duration = "4.35"
                },
                new Song
                {
                    Id = 2,
                    Title = "Cool",
                    Language = "Spanish",
                    Duration = "5.46"
                }
                );
        }
    }
}
