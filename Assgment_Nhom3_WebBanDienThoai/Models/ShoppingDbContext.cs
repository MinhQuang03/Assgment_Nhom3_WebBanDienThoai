using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;
using Assgment_Nhom3_WebBanDienThoai.Models;
namespace Assgment_Nhom3_WebBanDienThoai.Models
{
    public class ShoppingDbContext : DbContext
    {
        public ShoppingDbContext() { }
        public ShoppingDbContext(DbContextOptions<ShoppingDbContext> options) : base(options)
        {
        }

        public DbSet<Ram> Rams { get; set; }
        public DbSet<ChatLieu> ChatLieus { get; set; }

        public DbSet<BoNhoTrong> BoNhoTrong { get; set; }
        //public DbSet<Cart> Carts { get; set; }
        //public DbSet<BillDetail> billDetails { get; set; }
        //public DbSet<CartDetail> cartDetails { get; set; }
        //public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-H6TL71T\MINGG;Initial Catalog=IT17301_Shopping;User ID=minh160801;Password=minhanh321  ;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
