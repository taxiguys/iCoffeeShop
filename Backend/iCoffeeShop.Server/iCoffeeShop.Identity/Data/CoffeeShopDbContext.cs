using iCoffeeShop.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace iCoffeeShop.Identity.Data
{
    public class CoffeeShopDbContext : IdentityDbContext<User>
    {
        public CoffeeShopDbContext(DbContextOptions<CoffeeShopDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(users =>
                                 {
                                     users.ToTable("Users")
                                          .Property(c => c.Id)
                                          .HasColumnName("UserId");
                                     users.HasMany(c => c.Claims)
                                          .WithOne()
                                          .HasForeignKey(c => c.UserId)
                                          .IsRequired()
                                          .OnDelete(DeleteBehavior.Cascade);
                                 });

            builder.Entity<IdentityUserRole<string>>()
                   .ToTable("UserRoles");
            builder.Entity<IdentityUserLogin<string>>()
                   .ToTable("UserLogins");
            builder.Entity<IdentityUserClaim<string>>()
                   .ToTable("UserClaims");
            builder.Entity<IdentityUserToken<string>>()
                   .ToTable("UserTokens");
            builder.Entity<IdentityRoleClaim<string>>()
                   .ToTable("RoleClaims");
            builder.Entity<IdentityRole<string>>()
                   .ToTable("Roles");
        }
    }
}
