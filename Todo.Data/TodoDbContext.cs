using Microsoft.EntityFrameworkCore;
using Todo.Data.Models;

namespace Todo.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options)
        {

        }

        public DbSet<TodoEntity> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoEntity>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<TodoEntity>()
                .Property(p => p.Name)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}