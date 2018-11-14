using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nyw.Configuration.SqlServer {
    public static class SqlServerConfigurationExtensions {
        public static IConfigurationBuilder AddSqlServerConfiguration(this IConfigurationBuilder builder,Action<DbContextOptionsBuilder> optionsAction) {
            return builder.Add(new SqlServerConfigurationSource(optionsAction));
        }
    }
}
