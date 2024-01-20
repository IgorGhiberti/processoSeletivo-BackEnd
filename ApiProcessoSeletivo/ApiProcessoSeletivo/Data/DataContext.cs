using ApiProcessoSeletivo.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProcessoSeletivo.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-UCJQ3QE\\SQLEXPRESS;Integrated Security=True;Initial Catalog=AppDb;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>().HasIndex(f => f.DepartamentoId).IsUnique(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}
