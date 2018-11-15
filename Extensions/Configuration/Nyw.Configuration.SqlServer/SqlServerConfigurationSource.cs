using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Nyw.Configuration.SqlServer {
    public class SqlServerConfigurationSource: IConfigurationSource {
        private readonly Action<DbContextOptionsBuilder> _optionsAction;

        public SqlServerConfigurationSource(Action<DbContextOptionsBuilder> optionsAction) {
            _optionsAction = optionsAction;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder) {
            return new SqlServerConfigurationProvider(_optionsAction);
        }
    }
}
