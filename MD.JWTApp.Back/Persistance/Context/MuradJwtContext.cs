using MD.JWTApp.Back.Core.Domain;
using MD.JWTApp.Back.Persistance.Confugration;
using Microsoft.EntityFrameworkCore;

namespace MD.JWTApp.Back.Persistance.Context
{
    public class MuradJwtContext : DbContext
    {
        public MuradJwtContext(DbContextOptions<MuradJwtContext> options) : base(options)
        {

        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserConfigration());
            modelBuilder.ApplyConfiguration(new ProductConfugration());
            base.OnModelCreating(modelBuilder); 
        }

    }
}
