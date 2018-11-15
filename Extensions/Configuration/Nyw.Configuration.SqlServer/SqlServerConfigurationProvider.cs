using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nyw.Configuration.SqlServer {
    public class SqlServerConfigurationProvider : ConfigurationProvider {
        private Action<DbContextOptionsBuilder> OptionsAction { get; }
        public SqlServerConfigurationProvider(Action<DbContextOptionsBuilder> optionsAction) {
            OptionsAction = optionsAction;
        }

        // Load config data from EF DB.
        public override void Load() {
            var builder = new DbContextOptionsBuilder<AppConfigDbContext>();
            OptionsAction(builder);
            using (var dbContext = new AppConfigDbContext(builder.Options)) {
                dbContext.Database.EnsureCreated();
                Data = !dbContext.KeyValues.Any()
                    ? new Dictionary<string, string>()
                    : dbContext.KeyValues.ToDictionary(c => c.Id, c => c.Value);
            }
        }
        
    }
}
