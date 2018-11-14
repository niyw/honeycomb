using Microsoft.EntityFrameworkCore;

namespace Nyw.Configuration.SqlServer {
    public class AppConfigDbContext : DbContext {
        public DbSet<AppKeyValue> KeyValues { get; set; }
        public AppConfigDbContext(DbContextOptions options) : base(options) {
        }        
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<AppKeyValue>().ToTable("Tb_AppSettings").HasKey(kv=>kv.Id);
        }
    }
}
