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

        //Her iki variant dogrudur.
        public DbSet<AppUser> AppUsers{ get { return this.Set<AppUser>(); } }
        public DbSet<AppRole> AppRoles =>this.Set<AppRole>();
        public DbSet<Product> Products { get {return this.Set<Product>(); } }
        public DbSet<Category> Categories => this.Set<Category>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserConfigration());
            modelBuilder.ApplyConfiguration(new ProductConfugration());
            base.OnModelCreating(modelBuilder);
        }

    }
}
