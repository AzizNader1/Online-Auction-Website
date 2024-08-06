using Microsoft.EntityFrameworkCore;
using ZadProject.Models;

namespace ZadProject.Data
{
    public class ZadDbContext : DbContext
    {
        public ZadDbContext(DbContextOptions<ZadDbContext> options): base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<CarAuction> CarAuctions { get; set; }
        public DbSet<OtherAuction> OtherAuctions { get; set; }
        public DbSet<RealStateAuction> RealStateAuctions { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<BidingCarAuction> BidingCarAuctions { get; set; }
        public DbSet<BuyingCarAuction> BuyingCarAuctions { get; set; }
        public DbSet<BidingOtherAuction> BidingOtherAuctions { get; set; }
        public DbSet<BuyingOtherAuction> BuyingOtherAuctions { get; set; }
        public DbSet<BidingRealStateAuction> BidingRealStateAuctions { get; set; }
        public DbSet<BuyingRealStateAuction> BuyingRealStateAuctions { get; set; }
        public DbSet<Bank> Banks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BidingOtherAuction>()
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction); // Prevents cascading delete
        }
    }
}
