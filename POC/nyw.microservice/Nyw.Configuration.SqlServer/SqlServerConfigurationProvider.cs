using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nyw.Configuration.SqlServer {
    public class SqlServerConfigurationProvider : ConfigurationProvider {
        public SqlServerConfigurationProvider(Action<DbContextOptionsBuilder> optionsAction) {
            OptionsAction = optionsAction;
        }

        Action<DbContextOptionsBuilder> OptionsAction { get; }

        // Load config data from EF DB.
        public override void Load() {
            var builder = new DbContextOptionsBuilder<AppConfigDbContext>();
            OptionsAction(builder);
            using (var dbContext = new AppConfigDbContext(builder.Options)) {
                dbContext.Database.EnsureCreated();
                Data = !dbContext.KeyValues.Any()
                    ? CreateAndSaveDefaultValues(dbContext)
                    : dbContext.KeyValues.ToDictionary(c => c.Id, c => c.Value);
            }
        }

        private static IDictionary<string, string> CreateAndSaveDefaultValues(AppConfigDbContext dbContext) {
            var configValues = new Dictionary<string, string>{};

            dbContext.KeyValues.AddRange(configValues
                .Select(kvp => new AppKeyValue {
                    Id = kvp.Key,
                    Value = kvp.Value
                })
                .ToArray());

            dbContext.SaveChanges();

            return configValues;
        }
    }
}
