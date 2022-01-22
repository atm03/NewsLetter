using Microsoft.EntityFrameworkCore;

namespace NewsLetters.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
        public DbSet<News> News { get; set; }   
    }
}
