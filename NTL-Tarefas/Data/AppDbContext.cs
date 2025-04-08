using Microsoft.EntityFrameworkCore;
using NTL_Tarefas.Models;
using System.Collections.Generic;

namespace NTL_Tarefas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Tarefa> Tarefas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>().Property(t => t.DataCriacao).HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
