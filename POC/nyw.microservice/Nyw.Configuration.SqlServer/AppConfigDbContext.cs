using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nyw.Configuration.SqlServer {
    public class AppConfigDbContext : DbContext {
        public AppConfigDbContext(DbContextOptions options) : base(options) {
        }

        public DbSet<AppKeyValue> KeyValues { get; set; }
    }
}
