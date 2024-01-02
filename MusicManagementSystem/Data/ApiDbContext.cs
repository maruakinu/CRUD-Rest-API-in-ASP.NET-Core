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
    }
}
