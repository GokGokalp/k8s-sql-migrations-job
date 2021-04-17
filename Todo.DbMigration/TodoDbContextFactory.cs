using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Todo.Data;

namespace Todo.DbMigration
{
    public class TodoDbContextFactory : IDesignTimeDbContextFactory<TodoDbContext>
    {
        public TodoDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<TodoDbContext>();
 
            var connectionString = configuration
                        .GetConnectionString("SqlConnectionString");
        
            dbContextOptionsBuilder.UseSqlServer(connectionString, x => x.MigrationsAssembly("Todo.DbMigration"));
        
            return new TodoDbContext(dbContextOptionsBuilder.Options);
        }
    }
}