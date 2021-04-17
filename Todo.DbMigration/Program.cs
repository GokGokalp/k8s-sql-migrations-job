using System;
using Microsoft.EntityFrameworkCore;

namespace Todo.DbMigration
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new TodoDbContextFactory().CreateDbContext(args);

            dbContext.Database.Migrate();
        }
    }
}
