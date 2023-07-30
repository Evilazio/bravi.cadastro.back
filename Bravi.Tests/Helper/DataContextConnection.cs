using Bravi.Data.Database.Context;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Tests.Helper
{
    internal static class DataContextConnection
    {

        public static DbContextOptions<DataContext> GetConnection()
        {
            DbContextOptions<DataContext> dbContextOptions;
            var builder = new DbContextOptionsBuilder<DataContext>();
            var connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();
            dbContextOptions = builder.UseSqlite(connection).Options;
            return dbContextOptions;
        }
    }
}
