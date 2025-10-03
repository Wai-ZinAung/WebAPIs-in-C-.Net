using Microsoft.EntityFrameworkCore;
using StudentsCRUDAPIs.Models;

namespace StudentsCRUDAPIs.DAO
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }   
       public DbSet<Students> Students { get; set; }
    }
}