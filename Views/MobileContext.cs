using Microsoft.EntityFrameworkCore;

namespace MvcMovie.Models {
    public class MobileContext : DbContext {
        public DbSet<Phone> Phones {get;set;}

        public MobileContext(DbContextOptions<MobileContext> options) : base(options) {
            Database.EnsureCreated();
        }
    }
}