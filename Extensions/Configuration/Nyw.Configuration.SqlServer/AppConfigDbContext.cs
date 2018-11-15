using Microsoft.EntityFrameworkCore;

namespace Nyw.Configuration.SqlServer {
    public class AppConfigDbContext : DbContext {
        public DbSet<AppKeyValue> KeyValues { get; set; }
        public AppConfigDbContext(DbContextOptions options) : base(options) {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<AppKeyValue>().ToTable("Tb_AppSettings")
                .HasKey(k => new { k.AppId, k.Id });
            modelBuilder.Entity<AppKeyValue>().Property(p => p.AppId).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<AppKeyValue>().Property(p => p.Id).IsRequired().HasColumnName("SetKey").HasMaxLength(4000);
            modelBuilder.Entity<AppKeyValue>().Property(p => p.EnvironmentName).IsRequired().HasDefaultValue("Dev").HasMaxLength(20);
            modelBuilder.Entity<AppKeyValue>().Property(p => p.Value).HasColumnName("SetValue");
        }
    }
}
